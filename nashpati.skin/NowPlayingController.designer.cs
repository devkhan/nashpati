// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace nashpati.skin
{
	[Register ("NowPlayingController")]
	partial class NowPlayingController
	{
		[Outlet]
		AppKit.NSTableView NowPlayingList { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (NowPlayingList != null) {
				NowPlayingList.Dispose ();
				NowPlayingList = null;
			}
		}
	}
}
