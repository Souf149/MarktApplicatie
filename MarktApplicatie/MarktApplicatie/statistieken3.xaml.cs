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



            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "vorige week",
                    Values = new ChartValues<double> { 23, 37, 54, 62 }
                }
            };



            SeriesCollection.Add(new ColumnSeries
            {
                Title = "deze week",
                Values = new ChartValues<double> { 33, 28, 64 }
            });


            SeriesCollection[1].Values.Add(33d);

            Labels = new[] { "Sinasappels", "Ananas", "Kokosnoten", "Asperges" };
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
    }
}
