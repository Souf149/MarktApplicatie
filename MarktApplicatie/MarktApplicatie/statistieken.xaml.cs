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
    /// Interaction logic for statistieken.xaml
    /// </summary>
    public partial class statistieken : Window
    {
        public statistieken()
        {
            InitializeComponent();
        }

        private void onClick_homepage(object sender, MouseButtonEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }

        private void onClick_tijdelijk (object sender, MouseButtonEventArgs e)
        {
            tijdelijkstatscherm tijdelijk = new tijdelijkstatscherm();
            tijdelijk.Show();
            this.Close();
        }
    }
}
