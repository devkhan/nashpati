// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using AppKit;
using AVFoundation;

namespace nashpati.skin
{
	public partial class PlayerControlsController : NSViewController
	{
		static AVPlayer player { get; set; }

		public PlayerControlsController (IntPtr handle) : base (handle)
		{
			
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//player.Volume = VolumeSlider.FloatValue;
		}
	}
}
