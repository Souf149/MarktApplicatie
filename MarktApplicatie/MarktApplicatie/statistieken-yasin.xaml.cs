using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Newtonsoft.Json;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.Windows.Shapes;
using javax.sound.sampled;
using Path = System.IO.Path;

namespace MarktApplicatie
{
    /// <summary>
    /// Interaction logic for statistieken_yasin.xaml
    /// </summary>
    public partial class statistieken_yasin : Window
    {
        string[] composition_names;

        public statistieken_yasin()
        {
            InitializeComponent();




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


            UpdateList();

            if (composition_names.Length < 1)
            {
                MessageBox.Show("Je moet eerst een compositie opslaan!");
            }



            cartesianChart1.LegendLocation = LegendLocation.None;













        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }


        private void AddListViewItem(string filename)
        {

            // add item to the list if the filename ends with .json
            TextBlock b = new TextBlock()
            {
                Text = filename,
                FontSize = 24
            };

            listView.Items.Add(b);

        }

        private void ListView_onclick(object sender, MouseButtonEventArgs e)
        {

            if (listView.SelectedIndex < 0)
            {
                return;
            }

            Labels = new[] { "Appels", "Peren", "Citroenen", "Tomaten" };

            
            Formatter = value => value.ToString();

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    
                    Values = new ChartValues<double> { 13, 20, 44, 62 }
                }
            };

            DataContext = this;

        }


        

        private void UpdateList()
        {

            listView.Items.Clear();

            string[] files = SoufTools.GetAllCompositions();
            composition_names = new string[files.Length / 2];


            for (int i = 0, j = 0; i < files.Length; i++)
            {
                if (Path.GetExtension(files[i]) == ".json")
                {
                    composition_names[j++] = Path.GetFileNameWithoutExtension(files[i]);
                }
            }

            // for every file get the filename and add it to 
            foreach (string name in composition_names)
            {
                AddListViewItem(name);
            }

             

        }



        private void onClick_homepage(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();

        }


        private void comparison(object sender, RoutedEventArgs e)
        {
            

        }



        private void composition(object sender, RoutedEventArgs e)
        {

            new OudeComposities().Show();
            this.Close();

        }


        private void cirkeldiagram(object sender, RoutedEventArgs e)
        {

        }

        private void change(object sender, RoutedEventArgs e)
        {

        }

        private void Save(object sender, RoutedEventArgs e) //https://www.youtube.com/watch?v=D55E7Wor9Os source code
        {
            try
            {
                this.IsEnabled = false;

                PrintDialog printDialog = new PrintDialog();

                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(this, "cartesianChart1");
                }


            }
            finally
            {
                this.IsEnabled = true;
            }
        }


    }
}