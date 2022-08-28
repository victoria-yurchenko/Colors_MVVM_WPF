using Colors_MVVM.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Colors_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var view = new MainWindowViewModel();
            this.DataContext = view;
        }
    }
}
