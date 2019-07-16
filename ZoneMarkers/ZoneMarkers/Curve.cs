using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ZoneMarkers
{
    public class Curve
    {
        public Point[] Points { get; set; }
        public string xD { get; set; }
        public string yD { get; set; }
        public int NumPts { get; set; }
        public string dU { get; set; }
    }
}
