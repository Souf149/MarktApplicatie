﻿using System;
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
using System.Windows.Shapes;
using System.IO;
using LiveCharts;
using LiveCharts.Wpf;

namespace MarktApplicatie
{
    /// <summary>
    /// Interaction logic for statistieken.xaml
    /// </summary>


    public partial class statistieken : Window
    {
        public statistieken()
        {
            InitializeComponent();
            {
                this.Background = new SolidColorBrush(Colors.Black);
                this.Foreground = new SolidColorBrush(Colors.White);

                cartesianChart1.DataTooltip.Background = Brushes.Black;
                cartesianChart1.DataTooltip.Foreground = Brushes.White;
            }

            if (Settings1.Default.Darkmode == false)
            {
                this.Background = new SolidColorBrush(Colors.White);
                this.Foreground = new SolidColorBrush(Colors.Black);

                cartesianChart1.DataTooltip.Background = Brushes.White;
                cartesianChart1.DataTooltip.Foreground = Brushes.Black;
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

            //get data from vorige file and put it in a array
            StreamReader file1 = new StreamReader(@"vorige.txt");
            string line1;
            List<int> list1 = new List<int>();
            while ((line1 = file1.ReadLine()) != null)
            {
                list1.Add(int.Parse(line1));
            }

            int[] vorige = list1.ToArray();


            int[] vorigeweek = {10, 50, 39, 50 };
            int[] dezeweek = { 11, 56, 42, 48 };

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "vorige week",
                    Values = new ChartValues<double> { vorige[0], vorige[1], vorige[2], vorige[3] }
                }
            };


            //adding series will update and animate the chart automatically
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "deze week",
                Values = new ChartValues<double> { dezeweek[0], dezeweek[1], dezeweek[2], dezeweek[3] }
            });

            //also adding values updates and animates the chart automatically
            

            Labels = new[] { "Appels", "Peren", "Citroenen", "Tomaten" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }


        //add collections to xaml 
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        private void openHome(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }

        private void openStat2(object sender, RoutedEventArgs e)
        {
            statistieken2 stats = new statistieken2();
            stats.Show();
            this.Close();
        }

        private void openStat3(object sender, RoutedEventArgs e)
        {
            statistieken3 stats3 = new statistieken3();
            stats3.Show();
            this.Close();

        }
    }
}


