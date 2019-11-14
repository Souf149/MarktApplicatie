using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace MarktApplicatie {
    public class Plank {

        const int GRID_SIZE = 48;

        public int id;
        public Rectangle r;
        public static int selectedPlank = -1;
        List<Fruit> fruits = new List<Fruit>();

        int cols, rows;

        public void StandardConstructer() {
            id = -1;
            r = new Rectangle();
            cols = 0;
            rows = 0;
        }

        public Plank(int id_, Rectangle r_) {
            StandardConstructer();
            id = id_;
            r = r_;

            cols = (int)r.Width / GRID_SIZE;
            rows = (int)r.Height / GRID_SIZE;

            // initialize with null fruits
            for (int i = 0; i < cols * rows; i++) {
                fruits.Add(new Fruit(i, -1, this));
            }


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

        public void OnClick(int selectedFruit, int x, int y) {

            int col = (int)Math.Floor((double) x / GRID_SIZE);
            int row = (int)Math.Floor((double) y / GRID_SIZE);

            // index of pressed fruit in list
            int i = (row * cols) + col;

            fruits[i].Change(selectedFruit);
        }




    }

    public class Fruit{
        public Rectangle r;
        public int id;

        public Plank plank;

        public static List<string> fruitNames = new List<string>();


        public Fruit(int id_, int fruitId, Plank plank_) {
            id = id_;

            // parent
            plank = plank_;

            // make list of all current fruit TODO: ADD FROM FILE
            fruitNames.Add("appel");
            fruitNames.Add("banaan");
            fruitNames.Add("citroen");
            fruitNames.Add("limoen");

            if (fruitId != -1) {
                Change(fruitId);
            }
            else {
                r.Fill = SoufTools.GetColor("#010101");
            }
            
            
        }

        internal void Change(int selectedFruit) {

            // TODO: get fruits from file
            switch (fruitNames[selectedFruit].ToLower()) {
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
                    // this should never hit
                    r.Fill = SoufTools.GetColor("#FFFFFF");
                    break;

            }
        }
    }
}
