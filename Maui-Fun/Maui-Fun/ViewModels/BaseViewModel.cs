using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maui_Fun.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{
        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged([CallerMemberName] string name = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }
    }
}

