using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ZoneMarkers
{
    internal class CurveViewModel : INotifyPropertyChanged
    {
        private Curve[] curves;
        public Curve[] Curves
        {
            get { return curves; }
            set { curves = value; OnPropertyChanged("Curves"); }
        }

        public Func<double, string> Formatter { get; set; }

        public double Base { get; set; }

        public CurveViewModel()
        {
            Base = 10;
            Curves = new Curve[]
            {
                new Curve
                {
                    Points = new Point[]
                    {
                        new Point(1, 50),
                        new Point(1.25, 49),
                        new Point(1.6, 47),
                        new Point(2, 44.5),
                        new Point(2.5, 41),
                        new Point(3.0, 38),
                        new Point(3.15, 36.7),
                        new Point(4.0, 31.5),
                        new Point(5.0, 26.5),
                        new Point(6.0, 23),
                        new Point(6.3, 22),
                        new Point(7.13, 20),
                        new Point(8, 18),
                        new Point(10.0, 14.3),
                        new Point(200, 2)
                    },
                    dU = "A",
                },
                new Curve
                {
                    Points = new Point[]
                    {
                        new Point(1, 100),
                        new Point(1.25, 99),
                        new Point(1.6, 97),
                        new Point(2, 94.5),
                        new Point(2.5, 92),
                        new Point(3.0, 89),
                        new Point(3.15, 88),
                        new Point(4.0, 80),
                        new Point(5.0, 73),
                        new Point(6.0, 67),
                        new Point(6.3, 65),
                        new Point(7.13, 59.5),
                        new Point(8, 55),
                        new Point(10.0, 47),
                        new Point(200, 2)
                    },
                    dU = "B",
                },
                new Curve
                {
                    Points = new Point[]
                    {
                        new Point(1, 180),
                        new Point(1.25, 179),
                        new Point(1.6, 176),
                        new Point(2, 170),
                        new Point(2.5, 160),
                        new Point(3.0, 150),
                        new Point(3.15, 148),
                        new Point(4.0, 134),
                        new Point(5.0, 120),
                        new Point(6.0, 110),
                        new Point(6.3, 108),
                        new Point(7.13, 100),
                        new Point(8, 94),
                        new Point(10.0, 80),
                        new Point(200, 3)
                    },
                    dU = "C",
                },
                 new Curve
                {
                    Points = new Point[]
                    {
                        new Point(1, 300),
                        new Point(1.25, 298),
                        new Point(1.6, 293),
                        new Point(2, 283),
                        new Point(2.5, 267),
                        new Point(3.0, 250),
                        new Point(3.15, 247),
                        new Point(4.0, 223),
                        new Point(5.0, 200),
                        new Point(6.0, 183),
                        new Point(6.3, 180),
                        new Point(7.13, 167),
                        new Point(8, 157),
                        new Point(10.0, 133),
                        new Point(200, 5)
                    },
                    dU = "D",
                },
                new Curve
                {
                    Points = new Point[]
                    {
                        new Point(1, 400),
                        new Point(1.25, 398),
                        new Point(1.6, 391),
                        new Point(2, 378),
                        new Point(2.5, 356),
                        new Point(3.0, 333),
                        new Point(3.15, 329),
                        new Point(4.0,298),
                        new Point(5.0, 267),
                        new Point(6.0, 244),
                        new Point(6.3, 240),
                        new Point(7.13, 222),
                        new Point(8, 209),
                        new Point(10.0, 178),
                        new Point(200, 6.7)
                    },
                    dU = "E1",
                },
               new Curve
                {
                    Points = new Point[]
                    {
                        new Point(1, 500),
                        new Point(1.25, 497),
                        new Point(1.6, 489),
                        new Point(2, 472),
                        new Point(2.5, 444),
                        new Point(3.0, 417),
                        new Point(3.15, 411),
                        new Point(4.0, 372),
                        new Point(5.0, 333),
                        new Point(6.0, 305),
                        new Point(6.3, 300),
                        new Point(7.13, 278),
                        new Point(8, 261),
                        new Point(10.0, 222),
                        new Point(200, 8.3)
                    },
                    dU = "E2",
                },
            };
            Formatter = value => Math.Pow(Base, value).ToString();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            Console.WriteLine("Property of " + prop + " has changed");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}