using System;
namespace nashpati.skin
{
	public static class Extensions
	{
		public static string SimpleUrl(this Uri uri)
		{
			return uri.Host + uri.PathAndQuery + uri.Fragment;
		}
	}
}
