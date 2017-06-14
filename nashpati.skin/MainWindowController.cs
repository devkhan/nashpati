// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using AppKit;

namespace nashpati.skin
{
	public partial class MainWindowController : NSWindowController, IPreferencesListener
	{
		private static Preferences prefs;
		public static NSWindow MainWindow { get; private set; }

		public MainWindowController (IntPtr handle) : base (handle)
		{
			PreferenceManager.Default.Register(this);
			prefs = PreferenceManager.Default.GlobalPreferences;
		}

		public override void WindowDidLoad()
		{
			base.WindowDidLoad();

			MainWindow = this.Window;
			// Main window config.
			Window.TitleVisibility = NSWindowTitleVisibility.Hidden;
			Window.TitlebarAppearsTransparent = true;
			Window.MovableByWindowBackground = true;


		}

		public void PreferencesChanged(Preferences preferences)
		{
			prefs = preferences;

		}
	}
}
