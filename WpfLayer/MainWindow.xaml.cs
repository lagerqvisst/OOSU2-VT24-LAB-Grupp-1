﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfLayer.ViewModels;
using EntityLayer;

namespace WpfLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mainViewModel = new MainViewModel();
        public MainWindow()
        {
            //Vi bindar datacontexten till viewmodels. Detta återkommer i alla views i code behind.
            DataContext = mainViewModel;

            InitializeComponent();

            this.Title = "Sign in";

            
        }
    }
}