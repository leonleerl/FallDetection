using FallDetection.WPF.Common;
using FallDetection.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FallDetection.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // 加载 Google Maps 的 URL
            GoogleMapBrowser.Address = "https://www.google.com/maps";
            this.DataContext = new MainWindowViewModel();
        }

    }
}
