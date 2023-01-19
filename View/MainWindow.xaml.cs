using Sclad.ViewModel;
using System.Windows;

namespace Sclad.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM(); 
        }
    }
}
