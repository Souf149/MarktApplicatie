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
        public automatischplank_popup()
        {
            InitializeComponent();
        }

        public void makemycomposition_Click(object sender, RoutedEventArgs e)
        {
            var amount = amount_planks.Text;
            Console.WriteLine(amount);
            DialogResult = true;
        }
    }
}