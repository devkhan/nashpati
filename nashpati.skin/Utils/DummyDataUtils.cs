﻿using System;
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
				status: PlaylitItemStatus.DONE,
				filePath: Environment.GetEnvironmentVariable("TEST_VIDEOS_DIRECTORY") + "nIWAQK1CnXI.mp4"));
			list.Add(new PlaylistItem(
				videoUrl: "https://www.youtube.com/watch?v=whwQqMMyRPU",
				status: PlaylitItemStatus.DONE,
				filePath: Environment.GetEnvironmentVariable("TEST_VIDEOS_DIRECTORY") + "whwQqMMyRPU.mp4"));
			list.Add(new PlaylistItem(
				videoUrl: "https://www.youtube.com/watch?v=nEnLt3pasxE",
				title: "Neele Neele Ambar Par",
				status: PlaylitItemStatus.ERRORED,
				filePath: Environment.GetEnvironmentVariable("TEST_VIDEOS_DIRECTORY") + "nEnLt3pasxE.webm"));
			list.Add(new PlaylistItem(
				status: PlaylitItemStatus.NOT_DOWNLOADED,
				videoUrl: "https://www.instagram.com/p/BShYEK7AyUt/"));
			return list;
		}
	}
}
