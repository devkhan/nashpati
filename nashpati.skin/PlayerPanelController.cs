// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using AppKit;

namespace nashpati.skin
{
	public partial class PlayerPanelController : NSWindowController, IPreferencesListener
	{
		private static NSPanel PlayerPanel;
		private static Preferences prefs;

		public PlayerPanelController (IntPtr handle) : base (handle)
		{
			PreferenceManager.Default.Register(this);
			prefs = PreferenceManager.Default.GlobalPreferences;
		}

		public override void WindowDidLoad()
		{
			base.WindowDidLoad();
			PlayerPanel = (NSPanel)Window;

			PlayerPanel.StyleMask = NSWindowStyle.Borderless;
			PlayerPanel.MovableByWindowBackground = true;

			if (prefs.AttachedToMainWindow)
			{
                AttachToMainWindow();
			}
			else
			{
				DetachFromWindow();
			}
		}

		protected override void Dispose(bool disposing)
		{
			PreferenceManager.Default.UnRegister(this);
			base.Dispose(disposing);
		}

		async public void AttachToMainWindow()
		{
			PlayerPanel.TitleVisibility = NSWindowTitleVisibility.Hidden;
			PlayerPanel.StyleMask = NSWindowStyle.Borderless | NSWindowStyle.Utility;
			PlayerPanel.FloatingPanel = false;
			MainWindowController.MainWindow.AddChildWindow(PlayerPanel, NSWindowOrderingMode.Above);
		}

		async public void DetachFromWindow()
		{
			MainWindowController.MainWindow.RemoveChildWindow(this.Window);
			PlayerPanel.StyleMask = NSWindowStyle.Hud;
			PlayerPanel.FloatingPanel = true;
			Window.Level = NSWindowLevel.Dock;
			Window.CollectionBehavior = NSWindowCollectionBehavior.MoveToActiveSpace | NSWindowCollectionBehavior.FullScreenAuxiliary;
		}

		public void PreferencesChanged(Preferences preferences)
		{
			prefs = preferences;
			if (prefs.AttachedToMainWindow)
			{
				AttachToMainWindow();
			}
			else
			{
				DetachFromWindow();
			}
		}
	}
}
