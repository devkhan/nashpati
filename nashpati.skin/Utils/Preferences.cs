using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace nashpati.skin
{
	public class Preferences : INotifyPropertyChanged
	{
		// Not used right now.
		public enum PrefenceType
		{
			USER,
			DEFAULT,
			GLOBAL,
			PROFILE
		}

		private bool attachedToMainWindow = true;
		private PlaylistItem currentPlaying;
		private bool paused = false;

		[JsonProperty("attached_to_main_window")]
		public bool AttachedToMainWindow
		{
			get { return attachedToMainWindow; }
			set { SetProp(ref attachedToMainWindow, value); }
		}

		[JsonProperty("current_playing")]
		public PlaylistItem CurrentPlaying
		{
			get { return currentPlaying; }
			set { SetProp(ref currentPlaying, value); }
		}

		[JsonIgnore]
		public bool Paused
		{
			get { return paused; }
			set { SetProp(ref paused, value); }
		}

		public Preferences()
		{
		}

		protected bool SetProp<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
		{
			if (Equals(storage, value))
			{
				return false;
			}

			storage = value;
			this.OnPropertyChanged(propertyName);
			return true;
		}

		/// <summary>
		///     Notifies listeners that a property value has changed.
		/// </summary>
		/// <param name="propertyName">
		///     Name of the property used to notify listeners.  This
		///     value is optional and can be provided automatically when invoked from compilers
		///     that support <see cref="CallerMemberNameAttribute" />.
		/// </param>
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void ClearEventHandler()
		{
			PropertyChanged = null;
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
