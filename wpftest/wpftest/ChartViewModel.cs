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
            logarithmic = true;
        }

        private double XValue(double x)
        {
            if (x > 0 && logarithmic)
                return Math.Log10(x);
            else if (x <= 0 && logarithmic)
            {
                logarithmic = false;
                return x;
            }
            else if (x > 0 && !logarithmic)
            {
                logarithmic = true;
                return Math.Log10(x);
            }
            else // x <= 0 && !logarithmic
                return x;
        }

        internal void Refresh()
        {

            
            var mapper = Mappers.Xy<ObservablePoint>()
                .X(point => XValue(point.X))
                .Y(point => point.Y);

            SeriesCollection = new SeriesCollection(mapper)
            {
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 60),
                        new ObservablePoint(0.1, 58),
                        new ObservablePoint(0.2, 57),
                        new ObservablePoint(0.3, 56),
                        new ObservablePoint(0.4, 55),
                        new ObservablePoint(0.5, 54),
                        new ObservablePoint(0.6, 53),
                        new ObservablePoint(0.7, 52),
                        new ObservablePoint(0.8, 51),
                        new ObservablePoint(0.9, 50.5),
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

            Formatter = value => labelFormat(value);
        }

        private string labelFormat(double value)
        {
            if (logarithmic)
                return Math.Pow(Base, value).ToString("N");
            else
                return value.ToString("N");
        }

        private SeriesCollection seriesCollection;
        private Func<double, string> formatter;
        private double m_base;
        private bool logarithmic;
        private ChartValues<ObservablePoint> observablePoints;

        public SeriesCollection SeriesCollection
        {
            get { return seriesCollection; }
            set { seriesCollection = value; OnPropertyChanged("SeriesCollection"); }
        }

        public Func<double, string> Formatter
        {
            get { return formatter; }
            set { formatter = value; OnPropertyChanged("Formatter"); }
        }

        public double Base
        {
            get { return m_base; }
            set { m_base = value; OnPropertyChanged("Base"); }
        }

        public bool Logarithmic
        {
            get { return logarithmic; }
            set { logarithmic = value; OnPropertyChanged("Logarithmic"); }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public double Frequency { get; set; }
        public double A_zone { get; set; }
        public double B_zone { get; set; }
        public double C_zone { get; set; }
        public double D_zone { get; set; }
        public double E1_zone { get; set; }
        public double E2_zone { get; set; }
        public double F_zone { get; set; }
    }
}
