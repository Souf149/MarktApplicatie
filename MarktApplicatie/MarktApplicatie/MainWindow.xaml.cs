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
        public int FPS = Settings1.Default.speed;
        double angle = 0;
        double shapeAmount = 30;
        List<SoufShape> shapes = new List<SoufShape>();
        List<string> colors = new List<string>();

        int width = 800, height = 450;

        Random rng = new Random(DateTime.Now.Millisecond);

        public MainWindow()
        {
            InitializeComponent();


            


            if (Settings1.Default.Font8 == true)
            {
                btn.FontSize = 8;
                settings.FontSize = 8;
                oldcomp.FontSize = 8;
                stats.FontSize = 8;
            }

            if (Settings1.Default.Font10 == true)
            {
                btn.FontSize = 10;
                settings.FontSize = 10;
                oldcomp.FontSize = 10;
                stats.FontSize = 10;
            }

            if (Settings1.Default.Font12 == true)
            {
                btn.FontSize = 12;
                settings.FontSize = 12;
                oldcomp.FontSize = 12;
                stats.FontSize = 12;
            }

            if (Settings1.Default.Font14 == true)
            {
                btn.FontSize = 14;
                settings.FontSize = 14;
                oldcomp.FontSize = 14;
                stats.FontSize = 14;
            }

            if (Settings1.Default.Font16 == true)
            {
                btn.FontSize = 16;
                settings.FontSize = 16;
                oldcomp.FontSize = 16;
                stats.FontSize = 16;
            }

            if (Settings1.Default.Stilstaan == false)
            {
                CreateTimer();
            }

            if (Settings1.Default.lightmode == true)
            {
                canvas.Background = new SolidColorBrush(Colors.White);
            }

            if (Settings1.Default.lightblue == true)
            {
                canvas.Background = new SolidColorBrush(Colors.LightBlue);
            }
            
            if (Settings1.Default.blue == true)
            {
                canvas.Background = new SolidColorBrush(Colors.Blue);
                
            }

            if (Settings1.Default.darkblue == true)
            {
                canvas.Background = new SolidColorBrush(Colors.DarkBlue);
            }

            if (Settings1.Default.darkmodehome == true)

            {
                canvas.Background = new SolidColorBrush(Colors.Black);
            }




            SoufShape.canvas = canvas;

            // gets all custom fruit and adds it's colors to the list
            string[][] fruits = SoufTools.GetAllFruits();
            for(int i = 0; i < fruits.Length; i++) {
                colors.Add(fruits[i][1]);
            }

            if (Settings1.Default.verdwijnen == false)
            {
                // for every color there exists there is a shape
                for (int i = 0; i < shapeAmount; i++)
                {

                    Shape s;
                    int x = rng.Next(width);
                    int y = rng.Next(height);
                    int size = rng.Next(30, 50);


                    if (rng.NextDouble() < 0.5)
                    {
                        s = CreateSquare(x, y, size);
                    }
                    else
                    {
                        s = CreateCircle(x, y, size);
                    }

                    shapes.Add(new SoufShape(s));
                }
            

            }








        }

        
        
        private Rectangle CreateSquare(int x, int y, int size) {

            // chooses a random color from the list and applies it to the rectangle
            
            int i = new Random().Next(colors.Count);

            Rectangle r = new Rectangle() {
                Fill = SoufTools.GetColor(colors[i]),
                Width = size,
                Height = size,
                RadiusX = 5,
                RadiusY = 5
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
