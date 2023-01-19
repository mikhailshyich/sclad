using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Sclad.Model;
using Sclad.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sclad.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
        // все товары
        private List<Goods> allGoods = DataWorker.GetGoods();
        public List<Goods> AllGoods
        {
            get { return allGoods; }
            set
            {
                allGoods = value;
                NotifyPropertyChanged("AllGoods");
            }
        }

        //команды открытия окон
        private RelayCommand? openAddNewGoodsWnd;
        public RelayCommand OpenAddNewGoodsWnd
        {
            get
            {
                return openAddNewGoodsWnd ?? new RelayCommand(obj => { OpenAddGoodsWindowMethod(); });
            }
        }

        //методы открытия окон
        private void OpenAddGoodsWindowMethod()
        {
            AddNewGoods newGoodsWindow = new AddNewGoods();
            SetCenterPositionAndOpen(newGoodsWindow);
        }

        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
            
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyTitle)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyTitle));
            }
        }
    }
}
