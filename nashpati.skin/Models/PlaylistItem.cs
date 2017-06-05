using System;
using System.Diagnostics;
using Foundation;

namespace nashpati.skin
{
	[Register("PlaylistItem")]
	public class PlaylistItem : NSObject
	{
		string _title = null;
		Uri _video_url = null;

		[Export("Title")]
		public string Title
		{
			get
			{
				return _title != null && _title.Length != 0 ? _title : _video_url.SimpleUrl();
			}
			set
			{
				_title = value;
			}
		}

		[Export("VideoUrl")]
		public string VideoUrl
		{
			get
			{
				return _video_url.ToString();
			}
			set
			{
				var url = new Uri(value);
				Debug.Assert(url.IsWellFormedOriginalString());
				_video_url = url;
			}
		}

		[Export("VideoFilePath")]
		public string VideoFilePath { get; set; }

		[Export("isBufferable")]
		public bool IsBufferable { get; set; }

		[Export("isDownloaded")]
		public bool IsDownloaded { get; set; }

		public PlaylistItem()
		{
			IsBufferable = false;
			IsDownloaded = false;
		}

		public PlaylistItem(string videoUrl, string title = null, bool bufferable = false, bool downloaded = false, string filePath = "")
		{
			this.VideoUrl = videoUrl;
			this.Title = title;
			this.IsBufferable = bufferable;
			this.IsDownloaded = downloaded;
			this.VideoFilePath = filePath;
		}
	}
}
