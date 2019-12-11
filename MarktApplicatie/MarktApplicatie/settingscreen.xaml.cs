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
            Close();
        }

       

        

        private void Button_save(object sender, RoutedEventArgs e)
        {
            if (checkbox.IsChecked == true)
            {

                Settings1.Default.Message = false;
                Settings1.Default.Save();

            }

            MessageBox.Show("Instellingen opgeslagen!", "Instellingen", MessageBoxButton.OK, MessageBoxImage.Information);
            new settingscreen().Show();
            this.Close();
            


        }

        
    }


}

        


    

