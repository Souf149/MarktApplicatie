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
    /// Interaction logic for automatischplank_popup.xaml
    /// </summary>
    public partial class automatischplank_popup : Window
    {
        public bool fruittogether = false;
        
        public automatischplank_popup()
        {
            InitializeComponent();

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        public void makemycomposition_Click(object sender, RoutedEventArgs e)
        {
            //var amount = amount_planks.Text;
           // Console.WriteLine(amount);
            
            if (fruit_together.IsChecked == true)
            {
                fruittogether = true;
            }
            Console.WriteLine(fruittogether);
            DialogResult = true;
        }
    }
}
