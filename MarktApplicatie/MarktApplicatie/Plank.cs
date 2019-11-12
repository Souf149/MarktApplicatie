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
        int id;
        Rectangle r;

        public Plank(int id_, Rectangle r_)
        {
            id = id_;
            r = r_;
        }
    }
}
