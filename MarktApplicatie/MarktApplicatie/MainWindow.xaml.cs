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
        public const int FPS = 60;
        double angle = 0;
        List<Shape> shapes = new List<Shape>();
        List<string> colors = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            CreateTimer();

            string[][] fruits = SoufTools.GetAllFruits();

            for(int i = 0; i < fruits.Length; i++) {
                colors.Add(fruits[i][1]);
            }


            Rectangle r = CreateRect(50, 50, 100, 100);

            AddShape(r);



        }

        private Rectangle CreateRect(int x, int y, int width, int height) {

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

        private void AddShape(Shape s)
        {
            canvas.Children.Add(s);
            shapes.Add(s);
        }

        private void CreateTimer()
        {
            //  basic loop setup
            loopTimer = new DispatcherTimer();
            loopTimer.Tick += new EventHandler(Loop);
            loopTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / FPS);
            loopTimer.Start();
        }

        private void Loop(object sender, EventArgs e)
        {
            angle += 5 + new Random().NextDouble()*2;
            Shape s = shapes[0];
            s.RenderTransform = new RotateTransform(angle);
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
