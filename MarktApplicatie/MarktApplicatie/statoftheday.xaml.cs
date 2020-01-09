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

namespace MarktApplicatie
{
    /// <summary>
    /// Interaction logic for statoftheday.xaml
    /// </summary>
    public partial class statoftheday : Window
    {
        
        
        public int i = 0;
        public statoftheday()
        {
            InitializeComponent();

            if (Settings1.Default.Darkmode == true)
            {
                this.Background = new SolidColorBrush(Colors.Black);
                this.Foreground = new SolidColorBrush(Colors.White);
                checkbox.Foreground = new SolidColorBrush(Colors.White);
                
            }

            if (Settings1.Default.Darkmode == false)
            {
                this.Background = new SolidColorBrush(Colors.White);
                this.Foreground = new SolidColorBrush(Colors.Black);
                checkbox.Foreground = new SolidColorBrush(Colors.Black);
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

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            if (i==0)
            {
                textstat.Text = "Je hebt deze week 6 appels meer verkocht dan vorige week. Klik op de knop 'Statistiekenscherm' om deze statistiek direct te bekijken.";
                
            }


            



        }

        
        private void Sluiten(object sender, RoutedEventArgs e)
        {
            
           if (checkbox.IsChecked == true)
            {

                Settings1.Default.Message = true;
                Settings1.Default.msgoff = true;
                Settings1.Default.Save();

            }

            

            

            new MainWindow().Show();
            this.Close();



            

        }

        private void GoToStatistiekenscherm(object sender, RoutedEventArgs e)
        {

            if (checkbox.IsChecked == true)
            {
                Settings1.Default.msgoff = true;
                Properties.Settings.Default.Message = true;
                Properties.Settings.Default.Save();
            }

            
            
            if (i == 0)
            {
                
                new statistieken().Show();
                this.Close();
            }
            
            if (i == 1)
            {
                new statistieken2().Show();
                this.Close();
            }

            if (i == 2)
            {
                new statistieken3().Show();
                this.Close();
            }

        }

        private void NextStat(object sender, RoutedEventArgs e)
        {
            
            i += 1;
            if (i == 3)
            {
                i = 0;
                textstat.Text = "Je hebt deze week 6 peren meer verkocht dan vorige week. Klik op de knop 'Statistiekenscherm' om deze statistiek direct te bekijken.";
            }

            if (i == 1)
            {
                textstat.Text = "Je hebt deze maand gemiddeld 19 appels verkocht. Klik op de knop 'Statistiekenscherm' om deze statistiek direct te bekijken.";
            }

            if (i == 2)
            {
                textstat.Text = "Je hebt deze week 48 tomaten verkocht. Klik op de knop 'Statistiekenscherm' om deze statistiek direct te bekijken.";
            }


            if (checkbox.IsChecked == true)
            {

                Properties.Settings.Default.Message = true;
                Properties.Settings.Default.Save();
            }


        }

       
           

    }
}
