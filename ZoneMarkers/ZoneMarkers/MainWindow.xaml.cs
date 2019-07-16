using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using LiveCharts.Configurations;

namespace ZoneMarkers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Base = 10;

            // создается в конвертере, когда готовим SeriesCollection
            var mapper = Mappers.Xy<ObservablePoint>()
                .X(point => Math.Log(point.X, Base)) //a 10 base log scale in the X axis
                .Y(point => Math.Log(point.Y, Base));

            DataContext = new CurveViewModel();
        }

        public Func<double, string> Formatter { get; set; }
        public double Base { get; set; }
     
    }
}


