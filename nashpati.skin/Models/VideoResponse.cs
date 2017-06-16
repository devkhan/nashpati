using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace nashpati.skin
{
	public class VideoResponse
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("status")]
		public int Status { get; set; }

		[JsonProperty("timestamp")]
		public string Timestamp { get; set; }

		[JsonProperty("video_url")]
		public string VideoUrl { get; set; }

		[JsonProperty("info")]
		public Dictionary<string, object> Info;
	}
}
