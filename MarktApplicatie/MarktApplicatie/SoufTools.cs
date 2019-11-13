using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MarktApplicatie {
    public static class SoufTools {
        public static SolidColorBrush GetColor(string code) {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom(code));
        }
    }
}
