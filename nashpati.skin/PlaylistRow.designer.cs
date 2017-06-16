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
	[Register ("PlaylistRow")]
	partial class PlaylistRow
	{
		[Outlet]
		AppKit.NSProgressIndicator DownloadSpinner { get; set; }

		[Outlet]
		AppKit.NSButton InfoButton { get; set; }

		[Outlet]
		AppKit.NSImageView PlaylistItemThumbnail { get; set; }

		[Outlet]
		AppKit.NSView RootView { get; set; }

		[Outlet]
		AppKit.NSProgressIndicator Spinner { get; set; }

		[Outlet]
		AppKit.NSTextField TitleLabel { get; set; }

		[Outlet]
		AppKit.NSTextField UrlLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (InfoButton != null) {
				InfoButton.Dispose ();
				InfoButton = null;
			}

			if (PlaylistItemThumbnail != null) {
				PlaylistItemThumbnail.Dispose ();
				PlaylistItemThumbnail = null;
			}

			if (RootView != null) {
				RootView.Dispose ();
				RootView = null;
			}

			if (TitleLabel != null) {
				TitleLabel.Dispose ();
				TitleLabel = null;
			}

			if (UrlLabel != null) {
				UrlLabel.Dispose ();
				UrlLabel = null;
			}

			if (Spinner != null) {
				Spinner.Dispose ();
				Spinner = null;
			}

			if (DownloadSpinner != null) {
				DownloadSpinner.Dispose ();
				DownloadSpinner = null;
			}
		}
	}
}
