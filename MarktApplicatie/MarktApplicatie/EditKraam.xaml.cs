using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

namespace MarktApplicatie
{
    
    public partial class EditKraam : Window
    {
        Boolean mouseDown = false;
        selectedPlank = new Plank();

        List<Rectangle> rectangles = new List<Rectangle>();
        ArrayList planks = new ArrayList();

        SolidColorBrush currentFill = new SolidColorBrush(Colors.Red);
        int selectedFruit = -1;

        private TextBlock txtBlock(String t, String code)
        {
            return new TextBlock
            {
                Text = t,
                Background = getColor(code)
            };
        }

        private SolidColorBrush getColor(string code)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom(code));
        }

        private void SetColor(string code)
        {
            currentFill = getColor(code);
        }

        private Rectangle Rect(double x, double y, double w, double h)
        {


            Rectangle r = new Rectangle
            {
                Width = w,
                Height = h,
                Fill = currentFill
            };
            
            Canvas.SetLeft(r, x);
            Canvas.SetTop(r, y);

            rectangles.Add(r);
            canvas.Children.Add(r);
            return r;
        }


        public EditKraam()
        {
            // initialize window
            InitializeComponent();

            // TODO: ADD FROM FILE
            TextBlock txt = txtBlock("Test123", "#FF00FF");
            listView.Items.Add(txt);

            SetColor("#000000");
            Rect(200, 200, 200, 200);

            SetColor("#FF0000");
            Rect(100, 300, 50, 50);






        }

        private void go_home(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }

        private void go_bus(object sender, MouseButtonEventArgs e)
        {
            editbus editBus = new editbus();
            editBus.Show();
            this.Close();
        }

        private void ListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            selectedFruit = listView.SelectedIndex;
            debugText.Text = selectedFruit.ToString();
        }

        private void create_plank(object sender, MouseButtonEventArgs e)
        {
            plank_popup dialog = new plank_popup();
            int width = 0, height = 0;
            if(dialog.ShowDialog() == true)
            {
                debugText.Text = planks.Count.ToString();
                width = Convert.ToInt16(dialog.Inp_width);
                height = Convert.ToInt16(dialog.Inp_height);



                SetColor("#654321");

                Plank p = new Plank(
                    planks.Count,
                    Rect(0, 0, width * 16, height * 16)
                    );
                

            }
            
        }

        private void Canvas_onclick(object sender, MouseButtonEventArgs e) {
            Point p = e.GetPosition(this);
            mouseDown = true;

            positionText.Text = $"X: {p.X.ToString()}, \nY: {p.Y.ToString()}";

            Canvas.SetLeft(rectangles[0], p.X);
            Canvas.SetTop(rectangles[0], p.Y);

        }

        private void Canvas_onrelease(object sender, MouseButtonEventArgs e) {
            Point p = e.GetPosition(this);
            mouseDown = false;
        }

        private void Canvas_PreviewMouseMove(object sender, MouseEventArgs e) {
            Point p = e.GetPosition(this);
            if (mouseDown) {
                positionText.Text = $"X: {p.X.ToString()}, \nY: {p.Y.ToString()}";
                Canvas.SetLeft(rectangles[0], p.X);
                Canvas.SetTop(rectangles[0], p.Y);
            }
        }
    }
}
