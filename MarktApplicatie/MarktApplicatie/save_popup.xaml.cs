using System;
using System.Collections.Generic;
using System.IO;
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
using Newtonsoft.Json;

namespace MarktApplicatie
{
    /// <summary>
    /// Interaction logic for save_popup.xaml
    /// </summary>
    public partial class save_popup : Window {
        public save_popup() {
            InitializeComponent();
            if (Settings1.Default.Darkmode == true)
            {
               
                this.Background = new SolidColorBrush(Colors.Black);
                this.Foreground = new SolidColorBrush(Colors.White);
            }

            if (Settings1.Default.Darkmode == false)
            {
                
                this.Background = new SolidColorBrush(Colors.White);
                this.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        public string FileName {
            get { return inp_box.Text; }
        }

        private void Save(object sender, RoutedEventArgs e) 
        {
            MessageBox.Show("File Saved!");
            DialogResult = true;
        }
    }
}