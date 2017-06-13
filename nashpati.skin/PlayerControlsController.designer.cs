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
	[Register ("PlayerControlsController")]
	partial class PlayerControlsController
	{
		[Outlet]
		AppKit.NSButton PlayPauseButton { get; set; }

		[Outlet]
		AppKit.NSSlider VolumeSlider { get; set; }

		[Action ("PlayPauseButtonClicked:")]
		partial void PlayPauseButtonClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (VolumeSlider != null) {
				VolumeSlider.Dispose ();
				VolumeSlider = null;
			}

			if (PlayPauseButton != null) {
				PlayPauseButton.Dispose ();
				PlayPauseButton = null;
			}
		}
	}
}
