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
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;

namespace MarktApplicatie
{


    public partial class statistieken3 : Window
    {
        public statistieken3()
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

            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            DataContext = this;

            
        }

        public Func<ChartPoint, string> PointLabel { get; set; }
       


        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        private void openHome(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }

        private void openstats(object sender, RoutedEventArgs e)
        {
            statistieken stats = new statistieken();
            stats.Show();
            this.Close();
        }

        private void openstats2(object sender, RoutedEventArgs e)
        {
            statistieken2 stats2 = new statistieken2();
            stats2.Show();
            this.Close();
        }

        private void Save(object sender, RoutedEventArgs e) //https://www.youtube.com/watch?v=D55E7Wor9Os source code
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
    }
}
