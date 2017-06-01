using System;
namespace nashpati.skin
{
	public class FormatResponse
	{
		public FormatResponse()
		{
		}

		public int? downloaded_bytes { get; set; }
		public string format_id { get; set; }
		public string location { get; set; }
		public int status { get; set; }
		public int? total_bytes { get; set; }
		public string video_url { get; set; }
	}
}
