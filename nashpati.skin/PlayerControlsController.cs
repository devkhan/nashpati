// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using AppKit;
using AVFoundation;
using System.Threading.Tasks;

namespace nashpati.skin
{
	public partial class PlayerControlsController : NSViewController, IPreferencesListener
	{
		static AVPlayer player { get; set; }

		private static Preferences prefs;
		private static bool _attached;

		private NSImage playImage;
		private NSImage pauseImage;

		[Export("attached")]
		bool attached
		{
			get
			{
				return _attached;
			}
			set
			{
				WillChangeValue("attached");
				_attached = value;
				PreferenceManager.Default.GlobalPreferences.AttachedToMainWindow = value;
				DidChangeValue("attached");
			}
		}

		public PlayerControlsController (IntPtr handle) : base (handle)
		{
			PreferenceManager.Default.Register(this);
			prefs = PreferenceManager.Default.GlobalPreferences;
			_attached = prefs.AttachedToMainWindow;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			playImage = PlayPauseButton.Image;
			pauseImage = PlayPauseButton.AlternateImage;

			//player.Volume = VolumeSlider.FloatValue;
		}

		public void PreferencesChanged(Preferences preferences)
		{
			prefs = preferences;
			attached = prefs.AttachedToMainWindow;
		}

		public override void ViewDidDisappear()
		{
			PreferenceManager.Default.UnRegister(this);
			base.ViewDidDisappear();
		}

		partial void PlayPauseButtonClicked(NSObject sender)
		{
			PreferenceManager.Default.GlobalPreferences.Paused = !prefs.Paused;

			// Toggle play-pause icons.
			var temp = PlayPauseButton.Image;
			PlayPauseButton.Image = PlayPauseButton.AlternateImage;
			PlayPauseButton.AlternateImage = temp;
		}
	}
}
