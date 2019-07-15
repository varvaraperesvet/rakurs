using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace ZoneMarkers
{
    public class testConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<double> arrX = new List<double>();
            List<double> arrY = new List<double>();

            SeriesCollection series = (SeriesCollection)value;
            if (series != null)
            {
                foreach (var serie in series)
                {
                    LineSeries line = (LineSeries)serie;
                    {
                        if (series != null)
                        {
                            foreach (var point in line.ChartPoints)
                            {
                                arrX.Add(point.X);
                                arrY.Add(point.Y);
                            }
                        }

                    }
                }
                double distX = arrX.Max()-arrX.Min();
                Console.WriteLine(distX);
                throw new NotImplementedException();
            }
            else
                return new VisualElementsCollection() { new VisualElement() { X = 1, Y = 2, UIElement = new TextBlock() { Text = "ффух" } } };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
