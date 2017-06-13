using System;
using System.Collections.Generic;

namespace nashpati.skin
{
	public class DummyDataUtils
	{
		public static List<PlaylistItem> playlistItems()
		{
			var list = new List<PlaylistItem>();
			list.Add(new PlaylistItem(
				videoUrl: "https://www.youtube.com/watch?v=nIWAQK1CnXI",
				title: "What is a Date?",
				filePath: ""));
			list.Add(new PlaylistItem("https://www.youtube.com/watch?v=whwQqMMyRPU"));
			list.Add(new PlaylistItem("https://www.youtube.com/watch?v=nEnLt3pasxE", "Neele Neele Ambar Par"));
			list.Add(new PlaylistItem("https://www.instagram.com/p/BShYEK7AyUt/", downloaded: true));
			return list;
		}
	}
}
