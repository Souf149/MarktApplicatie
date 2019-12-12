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
    /// Interaction logic for statistiekenlijn.xaml
    /// </summary>
    public partial class statistiekenlijn : Window
    {
        public statistiekenlijn()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Appels",
                    Values = new ChartValues<double>{13,22,26,15}
                },
                new LineSeries
                {
                    Title = "Peren",
                    Values = new ChartValues<double>{20,88,68,22}
                },
                new LineSeries
                {
                    Title = "Citroenen",
                    Values = new ChartValues<double>{44,34,54,34}
                },
                new LineSeries
                {
                    Title = "Tomaten",
                    Values = new ChartValues<double>{62,55,33,21}
                }
            };
   
            Labels = new[] {"Week 1","Week 2","Week 3","Week 4" };
            YFormatter = value => value.ToString("C");

            DataContext = this;
            

        }

        public SeriesCollection SeriesCollection { get; set;  }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        private void openhome(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }

        private void openmaand(object sender, RoutedEventArgs e)
        {
            statistieken2 maand = new statistieken2();
            maand.Show();
            this.Close();
        }
    }
}
