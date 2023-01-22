using Sclad.Model;
using Sclad.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        //свойства для товаров
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
                        UpdateAllDataView();
                        ShowMessageToUser(resultStr);
                        SetNullValuesToPropertys();
                        wnd.Close();
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

        private void SetNullValuesToPropertys()
        {
            //для товаров
            GoodsTitle = null;
        }

        private void UpdateAllDataView()
        {
            UpdateAllGoodsView();
        }

        private void UpdateAllGoodsView()
        {
            AllGoods = DataWorker.GetGoods();
            MainWindow.AllGoodsView.ItemsSource = null;
            MainWindow.AllGoodsView.Items.Clear();
            MainWindow.AllGoodsView.ItemsSource = AllGoods;
            MainWindow.AllGoodsView.Items.Refresh();
        }
        
        private void ShowMessageToUser(string message)
        {
            MessageView messageView = new MessageView(message);
            SetCenterPositionAndOpen(messageView);
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
