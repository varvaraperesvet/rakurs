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
            int i = 0;
            double iks = 0;
            double igrik = 0;
            List <double> arrX = new List<double>();
            List <double> arrY = new List<double>();

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


                double distrikt = arrX.Max()-arrX.Min(); // задаём местоположение надписи по Х
                iks = distrikt * 0.25;

                i = 0;
                while (iks> arrX[i]) // борщ соответствующий igrik
                {
                    if (iks < arrX[i+1])
                    {
                        if ((iks - arrX[i]) > (arrX[i + 1]-iks))
                            igrik = arrY[i + 1] * 0.5;
                        else
                        {
                            igrik = arrY[i] * 0.5;
                        }

                        break;
                    }
                    i = i + 1;
                }


                return new VisualElementsCollection() { new VisualElement() { X = iks, Y = igrik, UIElement = new TextBlock() { Text = "A" } } };
            }
            else
                return new VisualElementsCollection() { new VisualElement() { X = iks, Y = igrik, UIElement = new TextBlock() { Text = "ффух" } } };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
