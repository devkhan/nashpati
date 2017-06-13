using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using static System.Environment;

namespace nashpati.skin
{
	public class PreferenceManager
	{
		private static readonly object padlock = new object();
		private static PreferenceManager instance = null;
		private ConcurrentDictionary<string, IPreferencesListener> preferenceListeners;
		private static Uri preferencesFileLocation = new Uri(Path.Combine(GetFolderPath(SpecialFolder.UserProfile), ".nashpati_config"));
		public Preferences GlobalPreferences { get; set; }

		private PreferenceManager()
		{
			preferenceListeners = new ConcurrentDictionary<string, IPreferencesListener>();
			if (File.Exists(preferencesFileLocation.AbsolutePath))
			{
				GlobalPreferences = JsonConvert.DeserializeObject<Preferences>(File.ReadAllText(preferencesFileLocation.AbsolutePath));
			}
			else
			{
				GlobalPreferences = new Preferences();
			}
			GlobalPreferences.PropertyChanged += (sender, e) =>
			{
				JsonSerializer serializer = new JsonSerializer();
				//serializer.Converters.Add(new JavaScriptDateTimeConverter());
				serializer.NullValueHandling = NullValueHandling.Include;
				serializer.Formatting = Formatting.Indented;
				using (StreamWriter sw = new StreamWriter(preferencesFileLocation.AbsolutePath))
				{
					using (JsonWriter writer = new JsonTextWriter(sw))
					{
						serializer.Serialize(writer, GlobalPreferences);
					}
				}
			};
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
