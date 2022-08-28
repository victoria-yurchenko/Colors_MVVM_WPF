using Colors_MVVM.Infrastructure;
using Colors_MVVM.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace Colors_MVVM.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<string> _colorNumbers;
        private RelayCommand _addCommand;
        private RelayCommand _deleteCommand;
        private MyColor _selectedColor;
        private MyColor _thisColor;

        private bool CanExecuteAddCommand(object parametr) => !_colorNumbers.Contains(ThisColor.ColorNumber);
        private bool CanExecuteDeleteCommand(object parametr) => SelectedColor != null;
        private void AddExecuteMethod(object parametr)
        {
            var color = new MyColor()
            {
                Alpha = ThisColor.Alpha,
                Red = ThisColor.Red,
                Green = ThisColor.Green,
                Blue = ThisColor.Blue
            };

            _colorNumbers.Add(color.ColorNumber);
            Colors.Add(color);
        }
        private void DeleteExecuteMethod(object parametr)
        {
            _colorNumbers.Remove(SelectedColor.ColorNumber);
            Colors.Remove(SelectedColor);
        }
        private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));




        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<MyColor> Colors { get; set; }
        public RelayCommand AddCommand => _addCommand ??= new RelayCommand(AddExecuteMethod, CanExecuteAddCommand);
        public RelayCommand DeleteCommand => _deleteCommand ??= new RelayCommand(DeleteExecuteMethod, CanExecuteDeleteCommand);
      

        public MyColor ThisColor
        {
            get => _thisColor;
            set
            {
                if (_thisColor != value)
                {
                    _thisColor = value;
                    OnPropertyChanged(nameof(this.ThisColor));
                }
            }
        }

        public MyColor SelectedColor
        {
            get => _selectedColor;
            set
            {
                if(value != _selectedColor)
                {
                    _selectedColor = value;
                    OnPropertyChanged(nameof(this.SelectedColor));
                }
            }
        }

        public MainWindowViewModel()
        {
            _colorNumbers = new List<string>();
            Colors = new ObservableCollection<MyColor>();
            ThisColor = new MyColor();
        }
    }
}
