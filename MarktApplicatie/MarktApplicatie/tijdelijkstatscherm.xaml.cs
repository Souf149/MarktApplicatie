using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace MarktApplicatie
{
    /// <summary>
    /// Interaction logic for tijdelijkstatscherm.xaml
    /// </summary>
    public partial class tijdelijkstatscherm : Window
    {
        public tijdelijkstatscherm()
        {
            InitializeComponent();
            
            if (Settings1.Default.Darkmode == true)
            {
                this.Background = new SolidColorBrush(Colors.Black);
                this.Foreground = new SolidColorBrush(Colors.White);
                twee.Foreground = new SolidColorBrush(Colors.White);
                drie.Foreground = new SolidColorBrush(Colors.White);
                vier.Foreground = new SolidColorBrush(Colors.White);
                peren.Foreground = new SolidColorBrush(Colors.White);
                Citroenen.Foreground = new SolidColorBrush(Colors.White);
                citroenen.Foreground = new SolidColorBrush(Colors.White);
            }

            if (Settings1.Default.Darkmode == false)
            {
                this.Background = new SolidColorBrush(Colors.White);
                this.Foreground = new SolidColorBrush(Colors.Black);
                twee.Foreground = new SolidColorBrush(Colors.Black);
                drie.Foreground = new SolidColorBrush(Colors.Black);
                vier.Foreground = new SolidColorBrush(Colors.Black);
                peren.Foreground = new SolidColorBrush(Colors.Black);
                Citroenen.Foreground = new SolidColorBrush(Colors.Black);
                citroenen.Foreground = new SolidColorBrush(Colors.Black);
            }

            if (Settings1.Default.Font8 == true)
            {
                FontSize = 8;
            }

            if (Settings1.Default.Font10 == true)
            {
                FontSize = 10;
            }

            if (Settings1.Default.Font12 == true)
            {
                FontSize = 12;
            }

            if (Settings1.Default.Font14 == true)
            {
                FontSize = 14;
            }

            if (Settings1.Default.Font16 == true)
            {
                FontSize = 16;
            }

        }

        private void onClick_homepage(object sender, MouseButtonEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();


        }

        private void prevWeek_OnClick(object sender, MouseButtonEventArgs e) {
            txt.Text = File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + @"\aaadata.txt");

        }

        private void thisWeek_OnClick(object sender, MouseButtonEventArgs e) {


            string data = txt1.Text + "," + txt2.Text + "," + txt3.Text;

            File.WriteAllText(System.AppDomain.CurrentDomain.BaseDirectory + @"\aaadata.txt", data);
            

        }
    }
}
