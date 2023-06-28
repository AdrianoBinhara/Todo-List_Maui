using System;
using System.ComponentModel;

namespace Maui_Fun.Models
{
	public class DayInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime Date { get; set; }
        public int DayOfMonth { get; set; }
		public string DayOfweek { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        private Color _backgroundColor;
        public Color BackgroundColor
        {
            get => _backgroundColor;
            set
            {
                if(_backgroundColor != value)
                {
                    _backgroundColor = value;
                    OnPropertyChanged(nameof(BackgroundColor));
                }
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

