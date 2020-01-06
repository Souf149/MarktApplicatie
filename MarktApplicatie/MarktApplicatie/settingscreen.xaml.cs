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
    // <summary>
    // Interaction logic for settingscreen.xaml
    // </summary>
    public partial class settingscreen : Window
    {
       
        public settingscreen()
        {
            InitializeComponent();
            if (Settings1.Default.checkdmon == true)
            {
                darkmode.IsChecked = true;
            }

            if (Settings1.Default.checkdmoff == true)
            {
                lightmode.IsChecked = true;
            }

            if (Settings1.Default.msgon == true)
            {
                checkbox.IsChecked = true;
            }

            if (Settings1.Default.msgoff == true)
            {
                checkbox2.IsChecked = true;
            }

            if (Settings1.Default.Darkmode == true)
            {
                this.Background = new SolidColorBrush(Colors.Black);
                this.Foreground = new SolidColorBrush(Colors.White);
                checkbox.Foreground = new SolidColorBrush(Colors.White);
                darkmode.Foreground = new SolidColorBrush(Colors.White);
                lightmode.Foreground = new SolidColorBrush(Colors.White);
                darkmodehome.Foreground = new SolidColorBrush(Colors.White);
                darkmodehome_off.Foreground = new SolidColorBrush(Colors.White);
                color1.Foreground = new SolidColorBrush(Colors.White);
                color2.Foreground = new SolidColorBrush(Colors.White);
                color3.Foreground = new SolidColorBrush(Colors.White);
                stil.Foreground = new SolidColorBrush(Colors.White);
                verdwijn.Foreground = new SolidColorBrush(Colors.White);
                Langzaam.Foreground = new SolidColorBrush(Colors.White);
                Normaal.Foreground = new SolidColorBrush(Colors.White);
                Snel.Foreground = new SolidColorBrush(Colors.White);
                checkbox2.Foreground = new SolidColorBrush(Colors.White);
                normalmode.Foreground = new SolidColorBrush(Colors.White);
            }

            if (Settings1.Default.Darkmode == false)
            {
                this.Background = new SolidColorBrush(Colors.White);
                this.Foreground = new SolidColorBrush(Colors.Black);
                checkbox.Foreground = new SolidColorBrush(Colors.Black);
                darkmode.Foreground = new SolidColorBrush(Colors.Black);
                lightmode.Foreground = new SolidColorBrush(Colors.Black);
                darkmodehome.Foreground = new SolidColorBrush(Colors.Black);
                darkmodehome_off.Foreground = new SolidColorBrush(Colors.Black);
                color1.Foreground = new SolidColorBrush(Colors.Black);
                color2.Foreground = new SolidColorBrush(Colors.Black);
                color3.Foreground = new SolidColorBrush(Colors.Black);
                stil.Foreground = new SolidColorBrush(Colors.Black);
                verdwijn.Foreground = new SolidColorBrush(Colors.Black);
                Langzaam.Foreground = new SolidColorBrush(Colors.Black);
                Normaal.Foreground = new SolidColorBrush(Colors.Black);
                Snel.Foreground = new SolidColorBrush(Colors.Black);
                normalmode.Foreground = new SolidColorBrush(Colors.Black);


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
            Settings1.Default.Stilstaan = true;
            Settings1.Default.speed = 50;
            Settings1.Default.Stilstaan = false;
            Settings1.Default.verdwijnen = false;
            Settings1.Default.darkmodehome = false;
            Settings1.Default.darkblue = false;
            Settings1.Default.blue = true;
            Settings1.Default.lightblue = false;
            Settings1.Default.lightmode = false;
            Settings1.Default.Darkmode = false;
            Settings1.Default.checkdmoff = true;
            Settings1.Default.checkdmon = false;
            Settings1.Default.msgon = true;
            Settings1.Default.msgoff = false;
            Settings1.Default.Save();
            MessageBox.Show("Instellingen gereset!", "Instellingen", MessageBoxButton.OK, MessageBoxImage.Information);
            new settingscreen().Show();
            this.Close();
        }

        

        private void Button_save(object sender, RoutedEventArgs e)
        {
            if (checkbox.IsChecked == true)
            {
                Settings1.Default.Message = false;
                Settings1.Default.msgon = true;
                Settings1.Default.msgoff = false;

            }

            if (checkbox2.IsChecked == true)
            {
                Settings1.Default.Message = true;
                Settings1.Default.msgoff = true;
                Settings1.Default.msgon = false;
            }

            if (darkmode.IsChecked == true)
            {
                Settings1.Default.Darkmode = true;
                Settings1.Default.checkdmon = true;
                Settings1.Default.checkdmoff = false;
            }

            if (lightmode.IsChecked == true)
            {
                Settings1.Default.Darkmode = false;
                Settings1.Default.checkdmoff = true;
                Settings1.Default.checkdmon = false;
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

            if (darkmodehome.IsChecked == true)
            {
                Settings1.Default.darkmodehome = true;
                Settings1.Default.darkblue = false;
                Settings1.Default.blue = false;
                Settings1.Default.lightblue = false;
                Settings1.Default.lightmode = false;

            }

            if (color1.IsChecked == true)
            {
                Settings1.Default.darkmodehome = false;
                Settings1.Default.darkblue = true;
                Settings1.Default.blue = false;
                Settings1.Default.lightblue = false;
                Settings1.Default.lightmode = false;
            }

            if (color2.IsChecked == true)
            {
                Settings1.Default.darkmodehome = false;
                Settings1.Default.darkblue = false;
                Settings1.Default.blue = true;
                Settings1.Default.lightblue = false;
                Settings1.Default.lightmode = false;
            }

            if (color3.IsChecked == true)
            {
                Settings1.Default.darkmodehome = false;
                Settings1.Default.darkblue = false;
                Settings1.Default.blue = false;
                Settings1.Default.lightblue = true;
                Settings1.Default.lightmode = false;
            }

            if (darkmodehome_off.IsChecked == true)
            {
                Settings1.Default.darkmodehome = false;
                Settings1.Default.darkblue = false;
                Settings1.Default.blue = false;
                Settings1.Default.lightblue = false;
                Settings1.Default.lightmode = true;

            }

            if (stil.IsChecked == true)
            {
                Settings1.Default.Stilstaan = true;
                Settings1.Default.verdwijnen = false;
            }

            if (Langzaam.IsChecked == true)
            {
                Settings1.Default.speed = 25;
                Settings1.Default.Stilstaan = false;
                Settings1.Default.verdwijnen = false;

            }

            if (Normaal.IsChecked == true)
            {
                Settings1.Default.speed = 50;
                Settings1.Default.Stilstaan = false;
                Settings1.Default.verdwijnen = false;
            }

            if (Snel.IsChecked == true)
            {
                Settings1.Default.speed = 75;
                Settings1.Default.Stilstaan = false;
                Settings1.Default.verdwijnen = false;
            }

            if (verdwijn.IsChecked == true)
            {
                Settings1.Default.Stilstaan = true;
                Settings1.Default.verdwijnen = true;
            }

            Settings1.Default.Save();
            MessageBox.Show("Instellingen opgeslagen!", "Instellingen", MessageBoxButton.OK, MessageBoxImage.Information);
            new settingscreen().Show();
            this.Close();



        }

        private void checkbox2_Checked(object sender, RoutedEventArgs e)
        {

        }
    }


}

        


    

