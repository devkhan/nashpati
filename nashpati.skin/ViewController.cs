using System;

using AppKit;
using Foundation;
using AVFoundation;

namespace nashpati.skin
{
	public partial class ViewController : NSViewController
	{
		AVPlayer player;
		AVPlayerLayer playerLayer;
		AVAsset asset;
		AVPlayerItem playerItem;

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			PlayerView.Player = new AVPlayer(new AVPlayerItem(AVAsset.FromUrl(NSUrl.FromFilename("trippy_bg.mp4"))));
			PlayerView.Player.Play();
		}

		public override NSObject RepresentedObject
		{
			get
			{
				return base.RepresentedObject;
			}
			set
			{
				base.RepresentedObject = value;
				// Update the view, if already loaded.
			}
		}

	}
}
