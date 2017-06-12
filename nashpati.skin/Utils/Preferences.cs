using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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

		public bool AttachedToMainWindow
		{
			get { return attachedToMainWindow; }
			set
			{
				SetProp(ref attachedToMainWindow, value);
			}
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
