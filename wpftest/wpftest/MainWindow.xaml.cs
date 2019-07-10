using System;
using System.Linq;
using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Configurations;
using LiveCharts.Defaults;

namespace wpftest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Chart.DataContext = new ChartViewModel();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((ChartViewModel)Chart.DataContext).refresh();
        }
    }
}