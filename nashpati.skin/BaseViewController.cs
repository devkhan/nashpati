using System;
using AppKit;

namespace nashpati.skin
{
	public class BaseViewController: NSViewController, IPreferencesListener
	{
		protected Preferences prefs;

		public BaseViewController(IntPtr handle) : base(handle)
		{
			PreferenceManager.Default.Register(this);
			prefs = PreferenceManager.Default.GlobalPreferences;
		}

		public virtual void PreferencesChanged(Preferences preferences)
		{
			prefs = preferences;
		}
	}
}
