using Sclad.ViewModel;
using System.Windows;

namespace Sclad.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewGoods.xaml
    /// </summary>
    public partial class AddNewGoods : Window
    {
        public AddNewGoods()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}
