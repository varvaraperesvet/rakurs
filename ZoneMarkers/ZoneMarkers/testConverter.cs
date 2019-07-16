using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ZoneMarkers
{
    public class testConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SeriesCollection series = (SeriesCollection)value;
            if (series != null)
            {
                VisualElementsCollection result = new VisualElementsCollection();
                LineSeries prevLine = null;
                foreach (var serie in series)
                {
                    LineSeries line = (LineSeries)serie;
                    {
                        if (series != null)
                        {
                            double iks = 0.25 * line.ChartPoints.Max(p => p.X);
                            ChartPoint игрик = line.ChartPoints.First(p => p.X > iks);
                            double gaga = игрик.Y* Math.Log(100, 10);
                            if (prevLine != null)
                            {
                                ChartPoint irgikOLD = prevLine.ChartPoints.OrderBy(p => p.X - iks).First();
                                gaga = (игрик.Y - irgikOLD.Y)*0.9+irgikOLD.Y;
                             }
                            result.Add(new VisualElement() { X = iks, Y = gaga, UIElement = new TextBlock() { Text = serie.Title, FontWeight = FontWeights.Bold, FontSize = 15}});
                        }
                    }
                    prevLine = line;
                }
                return result;
            }
            else
                return new VisualElementsCollection() { new VisualElement() };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
