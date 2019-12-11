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
    /// Interaction logic for settingscreen.xaml
    /// </summary>
    public partial class settingscreen : Window
    {
        public settingscreen()
        {
            InitializeComponent();
            if (Settings1.Default.Darkmode == true)
            {
                this.Background = new SolidColorBrush(Colors.Black);
                this.Foreground = new SolidColorBrush(Colors.White);
                checkbox.Foreground = new SolidColorBrush(Colors.White);
                darkmode_on.Foreground = new SolidColorBrush(Colors.White);
                darkmode_off.Foreground = new SolidColorBrush(Colors.White);
            }

            if (Settings1.Default.Darkmode == false)
            {
                this.Background = new SolidColorBrush(Colors.White);
                this.Foreground = new SolidColorBrush(Colors.Black);
                checkbox.Foreground = new SolidColorBrush(Colors.Black);
                darkmode_on.Foreground = new SolidColorBrush(Colors.Black);
                darkmode_off.Foreground = new SolidColorBrush(Colors.Black);
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


        }

        private void Home_button(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

       private void Button_reset(object sender, RoutedEventArgs e)
        {
            Settings1.Default.Darkmode = false;
            Settings1.Default.Message = false;
            Settings1.Default.Font8 = false;
            Settings1.Default.Font10 = false;
            Settings1.Default.Font12 = true;
            Settings1.Default.Font14 = false;
            Settings1.Default.Font16 = false;
            
            Settings1.Default.Save();
            MessageBox.Show("Instellingen gereset!, Fontsize=12", "Instellingen", MessageBoxButton.OK, MessageBoxImage.Information);
            new settingscreen().Show();
            this.Close();
        }

        

        private void Button_save(object sender, RoutedEventArgs e)
        {
            if (checkbox.IsChecked == true)
            {
                Settings1.Default.Message = false;
            }

            if (darkmode_on.IsChecked == true)
            {
                Settings1.Default.Darkmode = true;
            }

            if (darkmode_off.IsChecked == true)
            {
                Settings1.Default.Darkmode = false;
            }

            if (font8.IsChecked == true)
            {
                Settings1.Default.Font8 = true;
                Settings1.Default.Font10 = false;
                Settings1.Default.Font12 = false;
                Settings1.Default.Font14 = false;
                Settings1.Default.Font16 = false;
            }

            if (font10.IsChecked == true)
            {
                Settings1.Default.Font8 = false;
                Settings1.Default.Font10 = true;
                Settings1.Default.Font12 = false;
                Settings1.Default.Font14 = false;
                Settings1.Default.Font16 = false;
            }

            if (font12.IsChecked == true)
            {
                Settings1.Default.Font8 = false;
                Settings1.Default.Font10 = false;
                Settings1.Default.Font12 = true;
                Settings1.Default.Font14 = false;
                Settings1.Default.Font16 = false;
            }

            if (font14.IsChecked == true)
            {
                Settings1.Default.Font8 = false;
                Settings1.Default.Font10 = false;
                Settings1.Default.Font12 = false;
                Settings1.Default.Font14 = true;
                Settings1.Default.Font16 = false;
            }

            if (font16.IsChecked == true)
            {
                Settings1.Default.Font8 = false;
                Settings1.Default.Font10 = false;
                Settings1.Default.Font12 = false;
                Settings1.Default.Font14 = false;
                Settings1.Default.Font16 = true;
            }



            Settings1.Default.Save();
            MessageBox.Show("Instellingen opgeslagen!", "Instellingen", MessageBoxButton.OK, MessageBoxImage.Information);
            new settingscreen().Show();
            this.Close();




        }

        
    }


}

        


    

