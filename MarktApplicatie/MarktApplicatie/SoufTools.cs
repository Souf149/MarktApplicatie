using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MarktApplicatie {
    public static class SoufTools {

        public static int GRID_SIZE = 48;
        public static SolidColorBrush GetColor(string code) {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom(code));
        }
    }
}
