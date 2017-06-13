using System;
using System.Diagnostics;
using Foundation;
using Newtonsoft.Json;

namespace nashpati.skin
{
	[Register("PlaylistItem")]
	public class PlaylistItem : NSObject
	{
		string _title = null;
		Uri _video_url = null;

		[Export("Title")]
		[JsonProperty("title")]
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
		[JsonProperty("video_url")]
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
		[JsonProperty("file_path")]
		public string VideoFilePath { get; set; }

		[Export("isBufferable")]
		[JsonProperty("bufferable")]
		public bool IsBufferable { get; set; } = false;

		[Export("isDownloaded")]
		[JsonProperty("downloaded")]
		public bool IsDownloaded { get; set; } = false;

		[Export("At")]
		[JsonProperty("at")]
		public uint At { get; set; } = 0;

		public PlaylistItem()
		{
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
