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
        List<Shape> shapes = new List<Shape>();

        public MainWindow()
        {
            InitializeComponent();

            CreateTimer();


            Rectangle r = new Rectangle()
            {
                Fill = SoufTools.GetColor("#FF0000"),
                Width = 50,
                Height = 50
            };

            AddShape(r);



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
            angle += 10;
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
