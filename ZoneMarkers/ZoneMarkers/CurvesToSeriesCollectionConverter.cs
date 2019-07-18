using System;
using LiveCharts;
using LiveCharts.Wpf;
using System.Globalization;
using System.Windows.Data;
using LiveCharts.Defaults;
using LiveCharts.Configurations;
using System.Windows.Media;
using System.Windows.Controls;

namespace ZoneMarkers
{
    public class CurvesToSeriesCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int i= 0;
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
                        i= i + 1;
                        Curve line = curve;
                        {
                            
                            if (curve != null)
                            {
                                var L = new LineSeries
                                {
                                    Values = new ChartValues<ObservablePoint>(),
                                    PointGeometry=null,
                                };
                                Panel.SetZIndex(L, -i);
                                switch (i)
                                {
                                    case 1:
                                        L.Stroke= Brushes.Navy;
                                        L.Fill = Brushes.Navy;
                                        break;
                                    case 2:
                                        L.Stroke = Brushes.MediumBlue;
                                        L.Fill = Brushes.MediumBlue;
                                        break;
                                    case 3:
                                        L.Stroke = Brushes.Blue;
                                        L.Fill = Brushes.Blue;
                                        break;
                                    case 4:
                                        L.Stroke = Brushes.DodgerBlue;
                                        L.Fill = Brushes.DodgerBlue;
                                        break;
                                    case 5:
                                        L.Stroke = Brushes.Orange;
                                        L.Fill = Brushes.Orange;
                                        break;
                                    case 6:
                                        L.Stroke = Brushes.Red;
                                        L.Fill = Brushes.Red;
                                        break;
                                    default:
                                        L.Stroke = Brushes.Yellow;
                                        L.Fill = Brushes.Yellow;
                                        break;
                                }


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
