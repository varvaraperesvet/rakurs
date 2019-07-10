using System;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace wpftest
{
    public class ChartViewModel : INotifyPropertyChanged
    {
        public ChartViewModel()
        {
            Base = 10;
        }

        private string labelPoint(double point)
        {
            if (point >= 1)
                return Math.Pow(Base, point).ToString("N1");
            else if (point <= -1)
                return (-Math.Pow(Base, -point)).ToString("N1");
            else // point = (-1; 1)
                return point.ToString("N1");
        }

        private double XValue(double x)
        {
            if (x > 1)
                return Math.Log(x, Base);
            else if (x < -1)
            {
                return -Math.Log(-x, Base);
            }
            else // x = (-1; 1)
                return x;
        }

        internal void Refresh()
        {
            var mapper = Mappers.Xy<ObservablePoint>()
                .X(point => Math.Log(point.X, Base)) //a 10 base log scale in the X axis
                .Y(point => point.Y);

            SeriesCollection = new SeriesCollection(mapper)
            {
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        //new ObservablePoint(0, 0),
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
                    }
                }
            };

            Formatter = value => Math.Pow(Base, value).ToString("N");
            //Formatter = value => labelPoint(value);
        }

        public double Frequency { get; set; }
        public double A_zone { get; set; }
        public double B_zone { get; set; }
        public double C_zone { get; set; }
        public double D_zone { get; set; }
        public double E1_zone { get; set; }
        public double E2_zone { get; set; }
        public double F_zone { get; set; }

        private SeriesCollection seriesCollection;

        public SeriesCollection SeriesCollection
        {
            get { return seriesCollection; }
            set { seriesCollection = value; OnPropertyChanged("SeriesCollection"); }
        }

        private Func<double, string> formatter;

        public Func<double, string> Formatter
        {
            get { return formatter; }
            set { formatter = value; OnPropertyChanged("Formatter"); }
        }

        private double _base;

        public double Base
        {
            get { return _base; }
            set { _base = value; OnPropertyChanged("Base"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
