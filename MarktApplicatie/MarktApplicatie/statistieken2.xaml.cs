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


    public partial class statistieken2 : Window
    {
        public statistieken2()
        {
            InitializeComponent();
            if (Settings1.Default.Darkmode == true)
            {
                this.Background = new SolidColorBrush(Colors.Black);
                this.Foreground = new SolidColorBrush(Colors.White);
            }

            if (Settings1.Default.Darkmode == false)
            {
                this.Background = new SolidColorBrush(Colors.White);
                this.Foreground = new SolidColorBrush(Colors.Black);
            }


            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "week 1 ",
                    Values = new ChartValues<double> { 13, 20, 44, 62 }
                }
            };



            SeriesCollection.Add(new ColumnSeries
            {
                Title = "week 2",
                Values = new ChartValues<double> { 22, 88, 34 }
            });


            SeriesCollection[1].Values.Add(48d);

            SeriesCollection.Add(new ColumnSeries
            {
                Title = "week 3",
                Values = new ChartValues<double> { 26,68, 54, 33 }
            });

            SeriesCollection.Add(new ColumnSeries
            {
                Title = "week 4",
                Values = new ChartValues<double> { 15, 22, 34, 21 }
            });

            Labels = new[] { "Appels", "Peren", "Citroenen", "Tomaten" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }



        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        private void openHome(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }

        private void openstat(object sender, RoutedEventArgs e)
        {
            statistieken stats = new statistieken();
            stats.Show();
            this.Close();
        }

        private void openstat3(object sender, RoutedEventArgs e)
        {
            statistieken3 stats3 = new statistieken3();
            stats3.Show();
            this.Close();
        }
    }
}
