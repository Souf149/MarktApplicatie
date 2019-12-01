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
        }
        
        private void Home_button(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
           
            main.Show();
            this.Close();
        }

        private void playbutton_Click(object sender, RoutedEventArgs e)
        {
            var player = new MediaPlayer();
            player.Play();
        }

        private void stopbutton_Click(object sender, RoutedEventArgs e)
        {
            var player = new MediaPlayer();
            player.Stop();
        }

        private void Darkmode(object sender, RoutedEventArgs e)
        { 
            this.Background = new SolidColorBrush(Colors.Black);
            this.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Bigger_fontsize(object sender, RoutedEventArgs e)
        {
            this.FontSize = 20;
        }

        

        private void Smaller_fontsize(object sender, RoutedEventArgs e)
        {
            this.FontSize = 10;
        }

        private void Normalmode(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.White);
            this.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void Button_save(object sender, RoutedEventArgs e)
        {

        }

        private void Button_reset(object sender, RoutedEventArgs e)
        {
            
            this.FontSize = 10;
            this.Background = new SolidColorBrush(Colors.White);
            this.Foreground = new SolidColorBrush(Colors.Black);
        }
    }


}

        


    

