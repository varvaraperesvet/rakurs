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
    public class CurvesToZoneMarksConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Curve[] curves = (Curve[])value;
            if (curves != null)
            {
                VisualElementsCollection result = new VisualElementsCollection();
                Curve prevLine = null;
                foreach (var curve in curves)
                {
                    Curve line = curve;
                    {
                        if (curve != null)
                        {
                            double placeX = 0.25 * line.Points.Max(p => p.X);
                            double distY = line.Points.First(p => p.X > placeX).Y;
                            double placeY = distY * Math.Log(7, 10);
                            if (prevLine != null)
                            {
                                double prevdistY = prevLine.Points.OrderBy(p => p.X - placeX).First().Y;
                                placeY = (distY - prevdistY) * Math.Log(7, 10) + prevdistY;
                             }
                            result.Add(new VisualElement() { X = placeX, Y = placeY, UIElement = new TextBlock() { Text = curve.dU,
                                FontWeight = FontWeights.Bold, FontSize = 15, VerticalAlignment = VerticalAlignment.Top} });
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
