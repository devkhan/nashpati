using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace nashpati.skin
{
	public static class Sources
	{
		private enum SUPPORTED_SITES
		{
			[Description(@".*(?!www\.)(youtube.com\/watch).*")]
			YOUTUBE,
			[Description(@".*(?!www\.)(instagram.com\/p).*")]
			INSTAGRAM,
			[Description(@".*(?!www\.)(9gag.com\/gag).*")]
			NINEGAG,
			[Description(@".*(?!www\.)(vimeo.com\/)[0-9]+.*")]
			VIMEO,
			[Description(@".*(?!www\.)(dailymotion.com\/video\/).*")]
			DAILYMOTION
		}

		public static bool IsUrlSupported(string url)
		{
			foreach (SUPPORTED_SITES site in Enum.GetValues(typeof(SUPPORTED_SITES)))
			{
				Match match = Regex.Match(url, site.GetDescription(), RegexOptions.IgnoreCase, TimeSpan.FromSeconds(2));

				if (match.Success) return true;
			}
			return false;
		}
	}
}
