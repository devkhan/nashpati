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
	[Register ("AddNewController")]
	partial class AddNewController
	{
		[Outlet]
		AppKit.NSButton AddButton { get; set; }

		[Outlet]
		AppKit.NSTextField UrlInput { get; set; }

		[Action ("AddClicked:")]
		partial void AddClicked (Foundation.NSObject sender);

		[Action ("UrlInputAction:")]
		partial void UrlInputAction (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (UrlInput != null) {
				UrlInput.Dispose ();
				UrlInput = null;
			}

			if (AddButton != null) {
				AddButton.Dispose ();
				AddButton = null;
			}
		}
	}
}
