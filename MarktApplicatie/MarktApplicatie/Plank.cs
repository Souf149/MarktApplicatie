using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace MarktApplicatie {
    public class Plank {
        public int id;
        public Rectangle r;
        public static int selectedPlank = -1;
        List<Fruit> planks = new List<Fruit>();

        public void StandardConstructer() {
            id = -1;
            r = new Rectangle();
        }

        public Plank(int id_, Rectangle r_) {
            StandardConstructer();
            id = id_;
            r = r_;
        }

        public Plank() {
            StandardConstructer();
        }

        public void Check() {
            if (selectedPlank == id) {
                r.Stroke = SoufTools.GetColor("#00FF00");
            }
            else {
                r.Stroke = SoufTools.GetColor("#000000");
            }

        }


    }

    public class Fruit{
        public string name;
        public Rectangle r;
        public int id;


        public void StandardConstructer() {
            id = -1;
            r = new Rectangle();
            name = "";
        }

        public Fruit(int id_, string name_) {
            StandardConstructer();
            id = id_;
            name = name_;


            // TODO: get fruits from file
            switch (name.ToLower()) {
                case "appel":
                    r.Fill = SoufTools.GetColor("#FF0000");
                    break;
                case "banaan":
                    r.Fill = SoufTools.GetColor("#00AAAA");
                    break;
                case "citroen":
                    r.Fill = SoufTools.GetColor("#00AA55");
                    break;
                case "limoen":
                    r.Fill = SoufTools.GetColor("#00FF00");
                    break;
                default:
                    Console.WriteLine("Fruitnaam niet herkend");
                    break;

            }
        }

        public Fruit() {
            StandardConstructer();
        }





    }
}
