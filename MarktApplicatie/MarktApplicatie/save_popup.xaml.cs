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
    public partial class save_popup : Window
    {
        public save_popup(string strResultJson)
        {
            InitializeComponent();
            OudeComposities oc = new OudeComposities();
            
            savestuff(strResultJson);
        }

        public string savestuff(string strResultJson)
        {
            Console.WriteLine("test1: " + strResultJson);
            return strResultJson;
        }
        public void save(object sender, RoutedEventArgs e) 
        {
            MessageBox.Show("File Saved! Dont forget to close the popup.");
        }
    }
}