using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace MarktApplicatie {
    public class Plank {

        public const int GRID_SIZE = 48;
        public static Canvas c;

        public int id;
        public Rectangle r;
        public static int selectedPlank = -1;
        List<Fruit> fruits = new List<Fruit>();

        public int cols, rows;

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

        public void OnClick(int selectedFruit, double x, double y) {

            int col = Math.Abs((int)Math.Floor(x / GRID_SIZE));
            int row = Math.Abs((int)Math.Floor(y / GRID_SIZE));

            // index of pressed fruit in list
            int i = (row * cols) + col;
            try {
                fruits[i].Change(selectedFruit);
            } catch {
                
            }
            
        }

        public Rectangle[] GetAllFruitRect() {

            Rectangle[] rects = new Rectangle[fruits.Count];

            for(int i = 0; i < fruits.Count; i++) {
                rects[i] = fruits[i].r;
            }

            return rects;
        }

        internal void Move(double x, double y) {
            Canvas.SetLeft(r, x);
            Canvas.SetTop(r, y);

            foreach(Fruit f in fruits) {
                f.Move(x, y);
            }
        }
    }

    public class Fruit{
        public Rectangle r;
        public int id;
        public const int GRID_SIZE = 48;

        public Plank plank;

        public static List<string> fruitNames = new List<string>();

        public static Canvas c;

        public int x_on_plank;
        public int y_on_plank;


        public Fruit(int id_, int fruitId, Plank plank_) {
            id = id_;

            // parent
            plank = plank_;

            // make list of all current fruit TODO: ADD FROM FILE
            fruitNames.Add("appel");
            fruitNames.Add("banaan");
            fruitNames.Add("citroen");
            fruitNames.Add("limoen");

            // creating the rectangle
            r = new Rectangle {
                Width = GRID_SIZE - GRID_SIZE / 5,
                Height = GRID_SIZE - GRID_SIZE / 5
            };

            //TEMP
            r.Stroke = SoufTools.GetColor("#FF0000");

            double plank_x = Canvas.GetLeft(plank.r);
            double plank_y = Canvas.GetTop( plank.r);

            // get coordinates inside plank
            x_on_plank = id % plank.cols * GRID_SIZE;
            y_on_plank = id / plank.cols * GRID_SIZE;

            Move(plank_x, plank_y);



            // als hij geen null fruit is dan moet je kleur instellen
            if (fruitId != -1) {
                Change(fruitId);
            }
            else {
                r.Fill = SoufTools.GetColor("#010101");
            }

            c.Children.Add(r);
            
            
        }

        internal void Change(int selectedFruit) {
            if (selectedFruit < 0) {
                r.Fill = SoufTools.GetColor("#FFFFFF");
                return;
            }

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

        internal void Move(double x, double y) {
            Canvas.SetLeft(r, x_on_plank + x + GRID_SIZE / 10);
            Canvas.SetTop( r, y_on_plank + y + GRID_SIZE / 10);
        }
    }
}
