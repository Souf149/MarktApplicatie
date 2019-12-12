using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
using LiveCharts;
using LiveCharts.Wpf;
using Brushes = System.Windows.Media.Brushes;

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

            if (Settings1.Default.Darkmode == true)

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


            int[] vorigeweek = {10, 50, 39, 50 };
            int[] dezeweek = { 11, 56, 42, 48 };

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "vorige week",
                    Values = new ChartValues<double> { vorigeweek[0], vorigeweek[1], vorigeweek[2], vorigeweek[3] }
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

        private void Save (object sender, RoutedEventArgs e) //https://www.youtube.com/watch?v=D55E7Wor9Os source code
        {
            try
            {
                this.IsEnabled = false;

                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(cartesianChart1, "cartesianChart1");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
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


