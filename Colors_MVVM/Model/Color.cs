using System.ComponentModel;
using System.Windows.Media;

namespace Colors_MVVM.Model
{
    internal class MyColor : INotifyPropertyChanged
    {
        private const string _FormatHex = "X2";
        private byte _alpha;
        private byte _red;
        private byte _green;
        private byte _blue;

        private void NotifyOfPropertyChange(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public byte Alpha
        {
            get => _alpha;
            set
            {
                _alpha = value;
                NotifyOfPropertyChange(nameof(GetColor));
            }
        }

        public byte Red
        {
            get => _red;
            set
            {
                _red = value;
                NotifyOfPropertyChange(nameof(GetColor));
            }
        }

        public byte Green
        {
            get => _green;
            set
            {
                _green = value;
                NotifyOfPropertyChange(nameof(GetColor));
            }
        }

        public byte Blue
        {
            get => _blue; 
            set
            {
                _blue = value;
                NotifyOfPropertyChange(nameof(GetColor));
            }
        }

        public SolidColorBrush GetColor => new SolidColorBrush(Color.FromArgb(Alpha, Red, Green, Blue));
        public string ColorNumber => $"#{Alpha.ToString(_FormatHex)}{Red.ToString(_FormatHex)}{Green.ToString(_FormatHex)}{Blue.ToString(_FormatHex)}";

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
