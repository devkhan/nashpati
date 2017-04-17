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
		AppKit.NSTextField ClickedLabel { get; set; }

		[Action ("ClickedButton:")]
		partial void ClickedButton (AppKit.NSButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ClickedLabel != null) {
				ClickedLabel.Dispose ();
				ClickedLabel = null;
			}
		}
	}
}
