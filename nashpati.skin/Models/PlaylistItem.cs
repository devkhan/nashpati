using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using Foundation;
using Newtonsoft.Json;

namespace nashpati.skin
{
	public enum PlaylitItemStatus
	{
		PENDING,
		NOT_DOWNLOADED,
		DOWNLOADING,
		DONE,
		ERRORED
	}

	[DataContract]
	[Register("PlaylistItem")]
	public class PlaylistItem : NSObject
	{
		string _title = null;
		Uri _video_url = null;

		[JsonProperty("id")]
		[DataMember]
		public int? Id { get; set; } = null;

		[Export("Title")]
		[JsonProperty("title")]
		[DataMember]
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
		[DataMember]
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
		[DataMember]
		public string VideoFilePath { get; set; }

		[Export("isBufferable")]
		public bool IsBufferable { get { return !string.IsNullOrEmpty(VideoFilePath); } }

		[Export("isDownloaded")]
		public bool IsDownloaded { get { return Status == PlaylitItemStatus.DONE; } }

		[Export("At")]
		[JsonProperty("at")]
		[DataMember]
		public uint At { get; set; } = 0;

		[JsonProperty("status")]
		[DataMember]
		public PlaylitItemStatus Status { get; set; } = PlaylitItemStatus.PENDING;

		public string FormatId { get; set; }

		public PlaylistItem()
		{
		}

		public PlaylistItem(string videoUrl, int? id = null, string title = null, string filePath = "", PlaylitItemStatus status = PlaylitItemStatus.PENDING)
		{
			this.Id = id;
			this.VideoUrl = videoUrl;
			this.Title = title;
			this.VideoFilePath = filePath;
			this.Status = status;
		}
	}
}
