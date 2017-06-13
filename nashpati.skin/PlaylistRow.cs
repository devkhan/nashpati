using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace nashpati.skin
{
	public partial class PlaylistRow : NSView
	{
		private PlaylistItem item;

		[Export("item")]
		public PlaylistItem Item
		{
			get
			{
				return item;
			}
			set
			{
				WillChangeValue("item");
				item = value;
				DidChangeValue("item");
			}
		}

		#region Constructors

		// Called when created from unmanaged code
		public PlaylistRow(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public PlaylistRow(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		public PlaylistRow() : base()
		{
			NSArray array = new NSArray();
			NSBundle.MainBundle.LoadNibNamed("PlaylistRow", this, out array);
			AddSubview(RootView);
			Initialize();
		}

		// Shared initialization code
		void Initialize()
		{
			WantsLayer = true;
			Layer.BackgroundColor = new CoreGraphics.CGColor(0.2f, 0.2f, 0.2f, 0.5f);
		}

		#endregion

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
		}

		public void SetPlaylistItem(PlaylistItem item)
		{
			this.Item = item;
		}

		public override void MouseDown(NSEvent theEvent)
		{
			base.MouseDown(theEvent);
			Console.WriteLine("Mouse down on " + Item.Title);
		}
	}
}
