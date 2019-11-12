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
    /// Interaction logic for plank_popup.xaml
    /// </summary>
    public partial class plank_popup : Window
    {
        public plank_popup()
        {
            InitializeComponent();
        }

        public string Inp_width
        {
            get { return plank_width.Text; }
        }

        public string Inp_height
        {
            get { return plank_height.Text; }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (Inp_width.All(char.IsDigit) && Inp_width != "" &&
                Inp_height.All(char.IsDigit) && Inp_height != "")
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Wees zeker dat je hele getallen in alle velden invult.");
            }
            
        }
    }
}
