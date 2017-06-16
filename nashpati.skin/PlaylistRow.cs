using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using Refit;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace nashpati.skin
{
	public partial class PlaylistRow : NSView
	{
		private PlaylistItem item;
		private NashpatiInterface api;

		[Export("item")]
		public PlaylistItem Item
		{
			get
			{
				return item;
			}
			set
			{
				WillChangeValue("item");
				item = value;
				DidChangeValue("item");
			}
		}

		#region Constructors

		// Called when created from unmanaged code
		public PlaylistRow(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public PlaylistRow(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		public PlaylistRow() : base()
		{
			NSArray array = new NSArray();
			NSBundle.MainBundle.LoadNibNamed("PlaylistRow", this, out array);
			AddSubview(RootView);
			Initialize();

			var refitSettings = new RefitSettings();
			var jsonSettings = new JsonSerializerSettings();
			jsonSettings.NullValueHandling = NullValueHandling.Ignore;
			refitSettings.JsonSerializerSettings = jsonSettings;
			this.api = RestService.For<NashpatiInterface>("http://localhost:4444", refitSettings);

			Spinner.Hidden = true;
			DownloadSpinner.Hidden = true;
			DownloadSpinner.Indeterminate = false;
			DownloadSpinner.MinValue = 0;
		}

		// Shared initialization code
		void Initialize()
		{
			WantsLayer = true;
			//Layer.BackgroundColor = new CoreGraphics.CGColor(0.2f, 0.2f, 0.2f, 0.5f);
		}

		#endregion

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
		}

		async public void SetPlaylistItem(PlaylistItem item)
		{
			this.Item = item;

			PlaylistItemThumbnail.Hidden = true;
			Spinner.Hidden = false;
			Spinner.StartAnimation(this);

			var infoTask = DownloadVideoInfo(Item.VideoUrl);
			var video = await infoTask;
			Item.Id = video.Id;

			object formatId;
			if (video.Info.TryGetValue("format_id", out formatId))
			{
				if (((string)formatId).Contains('+'))
				{
					// FIXME(HIGH_PRIORITY): Combined formats (e.g. 248+251) doesn't work, and this is a very huge
					// problem rooted deep inside the architecture of the backend. The below line a very bad hack.
					formatId = "22";
				}
				Item.Status = PlaylitItemStatus.NOT_DOWNLOADED;
				Item.FormatId = (string)formatId;
				Spinner.StopAnimation(this);
				Spinner.Hidden = true;
				PlaylistItemThumbnail.Hidden = false;
				PlaylistItemThumbnail.Image = new NSImage(new NSUrl((string)video.Info["thumbnail"]));
			}
			switch (Item?.Status)
			{
				case PlaylitItemStatus.PENDING:
					
					break;

				case PlaylitItemStatus.NOT_DOWNLOADED:
					break;

				case PlaylitItemStatus.DOWNLOADING:
					break;

				case PlaylitItemStatus.DONE:
					break;

				case PlaylitItemStatus.ERRORED:
					break;
			}
		}

		public override void MouseUp(NSEvent theEvent)
		{
			base.MouseUp(theEvent);
		}

		async public override void MouseDown(NSEvent theEvent)
		{
			base.MouseDown(theEvent);
			if (theEvent.ClickCount > 1)
			{
				if (!Item.IsBufferable)
				{
					DownloadSpinner.Hidden = false;
					DownloadSpinner.StartAnimation(this);
					var formatTask = DownloadVideo(Item.FormatId);
					var format = await formatTask;
					Item.VideoFilePath = format.Location;
					DownloadSpinner.Hidden = true;
				}
				PreferenceManager.Default.GlobalPreferences.CurrentPlaying = Item;
				Console.WriteLine("Double click on " + Item.Title);
			}
			Console.WriteLine("Mouse down on " + Item.Title);
		}

		public override void MouseDragged(NSEvent theEvent)
		{
			base.MouseDragged(theEvent);
		}

		public override void MouseMoved(NSEvent theEvent)
		{
			base.MouseMoved(theEvent);
		}

		public override bool AcceptsFirstResponder()
		{
			return true;
		}

		async Task<VideoResponse> DownloadVideoInfo(string url)
		{
			var videoTask = api.SubmitVideo("{\"url\":\"" + url + "\"}");
			var video = await videoTask;
			while (video.Status != 3)
			{
				video = await api.GetVideoInfo(video.Id);
				Task.Delay(1000).Wait();
			}
			return video;
		}

		async Task<FormatResponse> DownloadVideo(string formatId)
		{
			var format = await api.StartDownload((int)Item.Id, formatId);

			while (format.Status != -2)
			{
				format = await api.GetDownlaod((int)Item.Id, format.FormatId);
				DownloadSpinner.MaxValue = (double)(format.TotalBytes ?? 0);
				DownloadSpinner.DoubleValue = (double)format.DownloadedBytes;
				await Task.Delay(1000);
			}
			return format;
		}
		
	}
}
