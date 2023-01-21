﻿using Sclad.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Sclad.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllGoodsView;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            AllGoodsView = ViewAllGoods;
        }
    }
}
