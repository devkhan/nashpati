using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace nashpati.skin
{
	public class PreferenceManager
	{
		private static readonly object padlock = new object();
		private static PreferenceManager instance = null;
		private ConcurrentDictionary<string, IPreferencesListener> preferenceListeners;
		private static Uri preferencesFileLocation;
		public Preferences GlobalPreferences { get; set; }

		private PreferenceManager()
		{
			preferenceListeners = new ConcurrentDictionary<string, IPreferencesListener>();
			GlobalPreferences = new Preferences();
		}

		public static PreferenceManager Default
		{
			get
			{
				lock (padlock)
				{
					if (instance == null)
					{
						instance = new PreferenceManager();
					}
					return instance;
				}
			}
		}

		public bool Register(IPreferencesListener listener, string tag = null)
		{
			preferenceListeners.AddOrUpdate(tag ?? listener.GetHashCode() + "", listener, (k, l) => l);
			GlobalPreferences.PropertyChanged += (sender, e) =>
			{
				// Old code.
				// Explanation - event handlers can be collected using +=, so we don't need to iterate over subscribers.
				//foreach (IPreferencesListener _listener in Default.preferenceListeners.Values)
				//{
				//	_listener.PreferencesChanged(GlobalPreferences);
				//}
				listener.PreferencesChanged(GlobalPreferences);
			};
			return true;
		}

		public bool UnRegister(IPreferencesListener listener, string key = null)
		{
			IPreferencesListener p;
			if (!preferenceListeners.TryRemove(key ?? listener.GetHashCode() + "", out p))
			{
				return false;
			}
			GlobalPreferences.ClearEventHandler();
			GlobalPreferences.PropertyChanged += (sender, e) =>
			{
				foreach (IPreferencesListener _listener in Default.preferenceListeners.Values)
				{
					_listener.PreferencesChanged(GlobalPreferences);
				}
			};
			return true;
		}
	}
}
