using System;
using LiveCharts;
using LiveCharts.Wpf;
using System.Globalization;
using System.Windows.Data;
using LiveCharts.Defaults;
using LiveCharts.Configurations;

namespace ZoneMarkers
{
    public class CurvesToSeriesCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CurveViewModel cur)
            {
                var mapper = Mappers.Xy<ObservablePoint>()
                    .X(point => Math.Log(point.X, cur.Base)) //a 10 base log scale in the X axis
                    .Y(point => Math.Log(point.Y, cur.Base));

                if (cur != null)
                {
                    SeriesCollection result = new SeriesCollection(mapper);
                    foreach (var curve in cur.Curves)
                    {
                        Curve line = curve;
                        {
                            if (curve != null)
                            {
                                var L = new LineSeries
                                {
                                    Values = new ChartValues<ObservablePoint>()
                                };
                                foreach (var p in line.Points)
                                {
                                    L.Values.Add(new ObservablePoint(p.X, p.Y));
                                }
                                result.Add(L);
                            }

                        }
                    }
                    return result;
                }
            }
            return null;
        }








        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
