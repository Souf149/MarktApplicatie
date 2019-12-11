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



        }

       



        private void Home_button(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
           
            main.Show();
            Close();
        }

       private void Button_reset(object sender, RoutedEventArgs e)
        {
            Settings1.Default.Darkmode = false;
            Settings1.Default.Message = false;
            Settings1.Default.Save();
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


            Settings1.Default.Save();
            MessageBox.Show("Instellingen opgeslagen!", "Instellingen", MessageBoxButton.OK, MessageBoxImage.Information);
            new settingscreen().Show();
            this.Close();
            


        }

        
    }


}

        


    

