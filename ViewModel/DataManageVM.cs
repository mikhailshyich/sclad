using Sclad.Model;
using Sclad.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        public string GoodsTitle { get; set; }

        //команды добавления товаров
        private RelayCommand addNewGoods;
        public RelayCommand AddNewGoods
        {
            get
            {
                return addNewGoods ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if(GoodsTitle == null || GoodsTitle.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "TitleBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateGoods(GoodsTitle);
                    }
                });
            }
        }

        //команды открытия окон
        private RelayCommand openAddNewGoodsWnd;
        public RelayCommand OpenAddNewGoodsWnd
        {
            get
            {
                return openAddNewGoodsWnd ?? new RelayCommand(obj =>
                {
                    OpenAddGoodsWindowMethod();
                }
                    );
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

        private void SetRedBlockControl(Window wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
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
