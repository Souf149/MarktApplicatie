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

namespace MarktApplicatie {
    /// <summary>
    /// Interaction logic for add_new_fruit.xaml
    /// </summary>
    public partial class add_new_fruit : Window {
        public add_new_fruit() {
            InitializeComponent();

           /* if (Settings1.Default.Darkmode == true)
            {
                this.Background = new SolidColorBrush(Colors.Black);
                this.Foreground = new SolidColorBrush(Colors.White);
                
            }

            if (Settings1.Default.Darkmode == false)
            {
                this.Background = new SolidColorBrush(Colors.White);
                this.Foreground = new SolidColorBrush(Colors.Black);
                
            }
            */

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

            MessageBox.Show("Kies een naam en je kleur (default value 255)");
        }

        public string Inp_red {
            get { return Get_default_if_empty(txt_red.Text);
            }
        }

        public string Inp_blue {
            get {
                return Get_default_if_empty(txt_blue.Text);
            }
        }
        public string Inp_green {
            get {
                return Get_default_if_empty(txt_green.Text);
            }
        }

        public string Inp_naam {
            get {
                return txt_naam.Text;
            }
        }

        public string Get_default_if_empty(string inp) {
            int int_inp = inp == "" ? 0 : Convert.ToInt32(inp);

            if (inp == "" || int_inp > 255 || int_inp < 0) {
                return "255";
            }
            else {
                return inp;
            }

        }

        private void OKButton_Click(object sender, MouseButtonEventArgs e) {


            if (Inp_naam == "") {
                MessageBox.Show("Geef het een naam");
                return;
            }

            if (!(Inp_red.All(char.IsDigit) &&
                Inp_blue.All(char.IsDigit) &&
                Inp_green.All(char.IsDigit))) {
                MessageBox.Show("De kleuren moeten hele getallen zijn tussen 0 en 256");
                return;
            }

            DialogResult = true;
            
            


        }
    }
}
