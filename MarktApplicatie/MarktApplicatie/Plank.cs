using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace MarktApplicatie
{
    public class Plank
    {
        public int id;
        public Rectangle r;
        public static int selectedPlank = -1;
        

        public void StandardConstructer() {
            id = -1;
            r = new Rectangle();
        }

        public Plank(int id_, Rectangle r_)
        {
            StandardConstructer();
            id = id_;
            r = r_;
        }

        public Plank() {
            StandardConstructer();
        }

        public void Check() {
            if(selectedPlank == id) {
                r.Stroke = SoufTools.GetColor("#00FF00");
            }
            else {
                r.Stroke = SoufTools.GetColor("#000000");
            }
            
        }
    }
}
