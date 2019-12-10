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

            if (i==0)
            {
                textstat.Text = "Je hebt deze week 20 appels meer verkocht dan vorige week. Klik op de knop 'Statistiekenscherm' om deze statistiek direct te bekijken.";

            }

        }

        private void Sluiten(object sender, RoutedEventArgs e)
        {
            
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();

            if (checkbox.IsChecked == true)
            {
               
            }

            




        }

        private void GoToStatistiekenscherm(object sender, RoutedEventArgs e)
        {
            
            statistieken statistieken = new statistieken();
            statistieken.Show();
            this.Close();

        }

        private void NextStat(object sender, RoutedEventArgs e)
        {
            i += 1;
            if (i == 3)
            {
                i = 0;
                textstat.Text = "Je hebt deze week 20 appels meer verkocht dan vorige week. Klik op de knop 'Statistiekenscherm' om deze statistiek direct te bekijken.";

            }

            if (i == 1)
            {
                textstat.Text = "Je hebt deze week 30 appels meer verkocht dan vorige week. Klik op de knop 'Statistiekenscherm' om deze statistiek direct te bekijken.";
            }

            if (i == 2)
            {
                textstat.Text = "Je hebt deze week 40 appels meer verkocht dan vorige week. Klik op de knop 'Statistiekenscherm' om deze statistiek direct te bekijken.";
            }

        }


    }
}
