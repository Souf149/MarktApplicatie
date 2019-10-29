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

namespace MarktApplicatie
{
    /// <summary>
    /// Interaction logic for tijdelijkstatscherm.xaml
    /// </summary>
    public partial class tijdelijkstatscherm : Window
    {
        public tijdelijkstatscherm()
        {
            InitializeComponent();
        }

        private void onClick_homepage(object sender, MouseButtonEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();


        }

        private void prevWeek_OnClick(object sender, MouseButtonEventArgs e) {
            

        }

        private void thisWeek_OnClick(object sender, MouseButtonEventArgs e) {


            string data = txt1.Text + "," + txt2.Text + "," + txt3.Text;

            File.WriteAllText(System.AppDomain.CurrentDomain.BaseDirectory + @"\aaadata.txt", data);
            

        }
    }
}
