using System;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using System.ComponentModel;
using System.Timers;

namespace wpftest
{
    public class ChartViewModel : INotifyPropertyChanged
    {
        private Timer timer;

        public ChartViewModel()
        {
            Base = 10;
            Formatter = value => Math.Pow(Base, value).ToString("N");
        }


        public double Base { get; set; }
        public double Frequency { get; set; }

        internal void refresh()
        {
            var mapper = Mappers.Xy<ObservablePoint>()
             .X(point => Math.Log(point.X, Base)) //a 10 base log scale in the X axis
             .Y(point => Math.Log(point.Y, Base)); //a 10 base log scale in the Y axis
            SeriesCollection = new SeriesCollection(mapper)
            {
               new StackedAreaSeries
               {
                    Title = "A",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0.8, 50),
                        new ObservablePoint(1, 50),
                        new ObservablePoint(1.25, 49),
                        new ObservablePoint(1.6, 47),
                        new ObservablePoint(2, 44.5),
                        new ObservablePoint(2.5, 41),
                        new ObservablePoint(3.0, 0), //38),
                        new ObservablePoint(3.15, 36.7),
                        new ObservablePoint(4.0, 31.5),
                        new ObservablePoint(5.0, 26.5),
                        new ObservablePoint(6.0, 23),
                        new ObservablePoint(6.3, 22),
                        new ObservablePoint(7.13, 20),
                        new ObservablePoint(8, 18),
                        new ObservablePoint(10.0, 14.3),
                        new ObservablePoint(12.5, 11.5),
                        new ObservablePoint(16, 9),
                        new ObservablePoint(20, 7),
                        new ObservablePoint(25, 5.6),
                        new ObservablePoint(30, 4.7),
                        new ObservablePoint(31.5, 4.44),
                        new ObservablePoint(40, 3.5),
                        new ObservablePoint(50, 2.8),
                        new ObservablePoint(63, 2.2),
                        new ObservablePoint(80, 2),
                        new ObservablePoint(100, 2),
                        new ObservablePoint(125, 2),
                        new ObservablePoint(160, 2),
                        new ObservablePoint(200, 2)
                    },
                    LineSmoothness = 0
                },
            };
        }

        public double A_zone { get; set; }
        public double B_zone { get; set; }
        public double C_zone { get; set; }
        public double D_zone { get; set; }
        public double E1_zone { get; set; }
        public double E2_zone { get; set; }
        public double F_zone { get; set; }
        public Func<double, string> Formatter { get; set; }

        private SeriesCollection seriesCollection;

        public SeriesCollection SeriesCollection
        {
            get { return seriesCollection; }
            set { seriesCollection = value; NotifyPropertyChanged("SeriesCollection"); }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void NotifyPropertyChanged(
            string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
