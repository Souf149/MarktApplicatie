using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MarktApplicatie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    

    public partial class MainWindow : Window
    {
        DispatcherTimer loopTimer;
        public const int FPS = 30;
        double angle = 0;
        List<SoufShape> shapes = new List<SoufShape>();
        List<string> colors = new List<string>();

        Random rng = new Random();

        public MainWindow()
        {
            InitializeComponent();

            CreateTimer();

            SoufShape.canvas = canvas;

            // gets all custom fruit and adds it's colors to the list
            string[][] fruits = SoufTools.GetAllFruits();
            for(int i = 0; i < fruits.Length; i++) {
                colors.Add(fruits[i][1]);
            }


            Rectangle r = CreateRect(50, 50, 50, 50);
            Ellipse c = CreateCircle(150, 50, 50);

            shapes.Add(new SoufShape(r));
            shapes.Add(new SoufShape(c));




        }

        private Rectangle CreateRect(int x, int y, int width, int height) {

            // chooses a random color from the list and applies it to the rectangle
            int i = new Random().Next(colors.Count);

            Rectangle r = new Rectangle() {
                Fill = SoufTools.GetColor(colors[i]),
                Width = width,
                Height = height
            };
            Canvas.SetLeft(r, x);
            Canvas.SetTop(r, y);

            return r;
        }

        private Ellipse CreateCircle(int x, int y, int diameter) {

            // chooses a random color from the list and applies it to the circle
            int i = rng.Next(colors.Count);

            Ellipse c = new Ellipse() {
                Fill = SoufTools.GetColor(colors[i]),
                Width = diameter,
                Height = diameter
            };
            Canvas.SetLeft(c, x);
            Canvas.SetTop(c, y);

            return c;
        }


        private void CreateTimer()
        {
            //  basic loop setup
            loopTimer = new DispatcherTimer();
            loopTimer.Tick += new EventHandler(Loop);
            loopTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / FPS);
            loopTimer.Start();
        }

        private void Loop(object sender, EventArgs e) {
            angle += 5 + rng.NextDouble() * 2;
            
            foreach (SoufShape shape in shapes) {
                shape.Update();
                shape.Rotate(angle); 
            }
        }

        private void OnClick_newComposition(object sender, MouseButtonEventArgs e) {
            new EditKraam().Show();
            Close();
        }
        private void OnClick_oldComposition(object sender, MouseButtonEventArgs e) {
            new OudeComposities().Show();
            Close();
        }

        private void OnClick_statistics(object sender, MouseButtonEventArgs e) {
            new statistieken().Show();
            Close();

        }

        private void OnClick_settings(object sender, MouseButtonEventArgs e) {
            new settingscreen().Show();
            Close();
        }

    }
}
