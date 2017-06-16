using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace nashpati.skin
{
	public class FormatResponse
	{
		public FormatResponse()
		{
		}

		[JsonProperty("downloaded_bytes")]
		public int? DownloadedBytes { get; set; }

		[JsonProperty("format_id")]
		public string FormatId { get; set; }

		[JsonProperty("location")]
		public string Location { get; set; }

		[JsonProperty("status")]
		public int Status { get; set; }

		[JsonProperty("total_bytes")]
		public int? TotalBytes { get; set; }

		[JsonProperty("video_url")]
		public string VideoUrl { get; set; }

		[JsonProperty("extra")]
		public Dictionary<string, object> Extra;
	}
}
