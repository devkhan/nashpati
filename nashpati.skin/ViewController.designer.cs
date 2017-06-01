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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSButton PlayButton { get; set; }

		[Outlet]
		AVKit.AVPlayerView PlayerView { get; set; }

		[Outlet]
		AppKit.NSProgressIndicator ProgressBar { get; set; }

		[Outlet]
		AppKit.NSTextField UrlInput { get; set; }

		[Action ("PlayButtonClicked:")]
		partial void PlayButtonClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (PlayButton != null) {
				PlayButton.Dispose ();
				PlayButton = null;
			}

			if (PlayerView != null) {
				PlayerView.Dispose ();
				PlayerView = null;
			}

			if (ProgressBar != null) {
				ProgressBar.Dispose ();
				ProgressBar = null;
			}

			if (UrlInput != null) {
				UrlInput.Dispose ();
				UrlInput = null;
			}
		}
	}
}
