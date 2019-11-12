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
        ArrayList rectangles = new ArrayList();
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

        private void setColor(string code)
        {
            currentFill = getColor(code);
        }

        private void Rect(double x, double y, double w, double h)
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
        }


        public EditKraam()
        {
            // initialize window
            InitializeComponent();

            // TODO: ADD FROM FILE
            TextBlock txt = txtBlock("Test123", "#FF00FF");
            listView.Items.Add(txt);

            setColor("#000000");
            Rect(200, 200, 200, 200);

            setColor("#FF0000");
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
            var dialog = new plank_popup();
            if (dialog.ShowDialog() == true)
            {
                debugText.Text = dialog.plank_width.Text;
            }
        }
    }
}
