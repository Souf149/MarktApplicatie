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
                    Title = "vorige week",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };


            //adding series will update and animate the chart automatically
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "deze week",
                Values = new ChartValues<double> { 11, 56, 42 }
            });

            //also adding values updates and animates the chart automatically
            SeriesCollection[1].Values.Add(48d);

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


