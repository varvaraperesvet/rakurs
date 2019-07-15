using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0.1, 2),
                        new ObservablePoint(7, 1),
                        new ObservablePoint(8, 0.5),
                        new ObservablePoint(11, 17)
                    },
                    LineSmoothness = 0
                },
                 new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0.1, 5),
                        new ObservablePoint(7, 9),
                        new ObservablePoint(8, 12),
                        new ObservablePoint(11, 20)
                    },
                    LineSmoothness = 0
                },
            };


            DataContext = this;

            //Xvalue = 0.3;
            //Yvalue = 0.9;

        }

        private SeriesCollection seriesCollection;
        //private double xvalue;
        //private double yvalue;

        public SeriesCollection SeriesCollection
        {
            get { return seriesCollection; }
            set { seriesCollection = value; OnPropertyChanged("SeriesCollection"); }
        }
        //public double Xvalue
        //{
        //    get { return xvalue; }
        //    set { xvalue = value; OnPropertyChanged("Xvalue"); }
        //}
        //public double Yvalue
        //{
        //    get { return yvalue; }
        //    set { yvalue = value; OnPropertyChanged("Yvalue"); }
        //}

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


