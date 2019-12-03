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
    /// Interaction logic for confirmation_popup.xaml
    /// </summary>
    public partial class confirmation_popup : Window {

        private bool result;
        public confirmation_popup() {
            InitializeComponent();
        }

        public bool Confirmation {
            get { return result; }
        }

        private void Deny_Click(object sender, RoutedEventArgs e) {
            result = false;
            DialogResult = true;
        }

        private void Accept_Click(object sender, RoutedEventArgs e) {
            result = true;
            DialogResult = true;
        }
    }
}
