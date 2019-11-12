using System;
using System.Collections;
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

namespace MarktApplicatie
{
    
    public partial class EditKraam : Window
    {
        ArrayList rectangles = new ArrayList();

        private TextBlock txtBlock(String t, String c)
        {
            TextBlock txt = new TextBlock();
            txt.Text = t;
            SolidColorBrush color = (SolidColorBrush)(new BrushConverter().ConvertFrom(c));
            txt.Background = color;
            return txt;
        }

        private void Rect(double x, double y, double w, double h)
        {


            Rectangle r = new Rectangle
            {
                Width = w,
                Height = h
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

            
            

                




        }

        private void onClick_homepage(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }

        private void onClick_editbus(object sender, MouseButtonEventArgs e)
        {
            editbus editBus = new editbus();
            editBus.Show();
            this.Close();
        }

    }
}