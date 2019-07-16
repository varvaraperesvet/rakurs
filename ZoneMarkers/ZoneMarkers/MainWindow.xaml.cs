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

            var mapper = Mappers.Xy<ObservablePoint>()
                .X(point => Math.Log(point.X, Base)) //a 10 base log scale in the X axis
                .Y(point => Math.Log(point.Y, Base));

            SeriesCollection = new SeriesCollection(mapper)
            {
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0.8, 50),
                        new ObservablePoint(1, 50),
                        new ObservablePoint(1.25, 49),
                        new ObservablePoint(1.6, 47),
                        new ObservablePoint(2, 44.5),
                        new ObservablePoint(2.5, 41),
                        new ObservablePoint(3.0, 38),
                        new ObservablePoint(3.15, 36.7),
                        new ObservablePoint(4.0, 31.5),
                        new ObservablePoint(5.0, 26.5),
                        new ObservablePoint(6.0, 23),
                        new ObservablePoint(6.3, 22),
                        new ObservablePoint(7.13, 20),
                        new ObservablePoint(8, 18),
                        new ObservablePoint(10.0, 14.3)
                    },
                    LineSmoothness = 0,
                    Title = "A"
                },
                 new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0.8, 100),
                        new ObservablePoint(1, 100),
                        new ObservablePoint(1.25, 99),
                        new ObservablePoint(1.6, 97),
                        new ObservablePoint(2, 94.5),
                        new ObservablePoint(2.5, 92),
                        new ObservablePoint(3.0, 89),
                        new ObservablePoint(3.15, 88),
                        new ObservablePoint(4.0, 80),
                        new ObservablePoint(5.0, 73),
                        new ObservablePoint(6.0, 67),
                        new ObservablePoint(6.3, 65),
                        new ObservablePoint(7.13, 59.5),
                        new ObservablePoint(8, 55),
                        new ObservablePoint(10.0, 47)
                    },
                    LineSmoothness = 0,
                    Title = "B"
                },
                 new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0.8, 180),
                        new ObservablePoint(1, 180),
                        new ObservablePoint(1.25, 179),
                        new ObservablePoint(1.6, 176),
                        new ObservablePoint(2, 170),
                        new ObservablePoint(2.5, 160),
                        new ObservablePoint(3.0, 150),
                        new ObservablePoint(3.15, 148),
                        new ObservablePoint(4.0, 134),
                        new ObservablePoint(5.0, 120),
                        new ObservablePoint(6.0, 110),
                        new ObservablePoint(6.3, 108),
                        new ObservablePoint(7.13, 100),
                        new ObservablePoint(8, 94),
                        new ObservablePoint(10.0, 80)
                    },
                    LineSmoothness = 0,
                    Title = "C"
                },
                 new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0.8, 300),
                        new ObservablePoint(1, 300),
                        new ObservablePoint(1.25, 298),
                        new ObservablePoint(1.6, 293),
                        new ObservablePoint(2, 283),
                        new ObservablePoint(2.5, 267),
                        new ObservablePoint(3.0, 250),
                        new ObservablePoint(3.15, 247),
                        new ObservablePoint(4.0, 223),
                        new ObservablePoint(5.0, 200),
                        new ObservablePoint(6.0, 183),
                        new ObservablePoint(6.3, 180),
                        new ObservablePoint(7.13, 167),
                        new ObservablePoint(8, 157),
                        new ObservablePoint(10.0, 133)
                    },
                    LineSmoothness = 0,
                    Title = "D"
                },
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0.8, 400),
                        new ObservablePoint(1, 400),
                        new ObservablePoint(1.25, 398),
                        new ObservablePoint(1.6, 391),
                        new ObservablePoint(2, 378),
                        new ObservablePoint(2.5, 356),
                        new ObservablePoint(3.0, 333),
                        new ObservablePoint(3.15, 329),
                        new ObservablePoint(4.0,298),
                        new ObservablePoint(5.0, 267),
                        new ObservablePoint(6.0, 244),
                        new ObservablePoint(6.3, 240),
                        new ObservablePoint(7.13, 222),
                        new ObservablePoint(8, 209),
                        new ObservablePoint(10.0, 178)
                    },
                    LineSmoothness = 0,
                    Title = "E1"
                },
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0.8, 500),
                        new ObservablePoint(1, 500),
                        new ObservablePoint(1.25, 497),
                        new ObservablePoint(1.6, 489),
                        new ObservablePoint(2, 472),
                        new ObservablePoint(2.5, 444),
                        new ObservablePoint(3.0, 417),
                        new ObservablePoint(3.15, 411),
                        new ObservablePoint(4.0, 372),
                        new ObservablePoint(5.0, 333),
                        new ObservablePoint(6.0, 305),
                        new ObservablePoint(6.3, 300),
                        new ObservablePoint(7.13, 278),
                        new ObservablePoint(8, 261),
                        new ObservablePoint(10.0, 222)
                    },
                    LineSmoothness = 0,
                    Title = "E2",
                },
  
            };

            Formatter = value => Math.Pow(Base, value).ToString("N");

            DataContext = this;

        }

        private SeriesCollection seriesCollection;
        public SeriesCollection SeriesCollection
        {
            get { return seriesCollection; }
            set { seriesCollection = value; OnPropertyChanged("SeriesCollection"); }
        }

        public Func<double, string> Formatter { get; set; }
        public double Base { get; set; }

        private bool elements;
        public bool Elements
        {
            get { return elements; }
            set { elements = value; OnPropertyChanged("Elements"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            Console.WriteLine("Property of " + prop + " has changed");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}


