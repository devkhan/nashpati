using System;

using AppKit;
using Foundation;
using AVFoundation;
using System.Threading.Tasks;
using Refit;

namespace nashpati.skin
{
	public partial class ViewController : NSViewController
	{
		NashpatiInterface api;
		VideoResponse video;
		FormatResponse format;

		public ViewController(IntPtr handle) : base(handle)
		{
			this.api = RestService.For<NashpatiInterface>("http://localhost:4444");
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			ProgressBar.Hidden = true;
			PlayerView.Hidden = true;
			UrlInput.Hidden = false;
			PlayButton.Hidden = false;
			

		}

		async partial void PlayButtonClicked(Foundation.NSObject sender)
		{
			string url = UrlInput.StringValue;
			Console.WriteLine("Video URL: " + url);
			UrlInput.Hidden = true;
			PlayButton.Hidden = true;
			ProgressBar.Hidden = false;
			ProgressBar.StartAnimation(sender);

			await DownloadVideo(url);

		}

		async Task DownloadVideo(string url)
		{
			video = await api.SubmitVideo("{\"url\":\"" + url + "\"}");
			while (video.status != 3)
			{
				video = await api.GetVideoInfo(video.id);
				await Task.Delay(1000);
			}
			var format_id = "22";
			if (url.Contains("vimeo")) format_id = "http-540p";
			format = await api.StartDownload(video.id, format_id);
			while (format.status != -2)
			{
				format = await api.GetDownlaod(video.id, format.format_id);
				await Task.Delay(1000);
			}
			ProgressBar.Hidden = true;
			PlayerView.Hidden = false;
			PlayerView.Player = new AVPlayer(new AVPlayerItem(AVAsset.FromUrl(NSUrl.FromFilename(format.location))));

			PlayerView.Player.Play();
		}

		public override NSObject RepresentedObject
		{
			get
			{
				return base.RepresentedObject;
			}
			set
			{
				base.RepresentedObject = value;
				// Update the view, if already loaded.
			}
		}

	}
}
