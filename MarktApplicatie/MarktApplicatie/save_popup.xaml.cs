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

        public save_popup(List<Plank> planks)
        {
            InitializeComponent();
            OudeComposities oc = new OudeComposities();
            
            tab1.Content = oc.tab1.Header;
            tab2.Content = oc.tab2.Header;
            tab3.Content = oc.tab3.Header;
            tab4.Content = oc.tab4.Header;
            tab5.Content = oc.tab5.Header;
            tab6.Content = oc.tab6.Header;
            tab7.Content = oc.tab7.Header;
            tab8.Content = oc.tab8.Header;
            EditKraam ek = new EditKraam();
            PlankInfo[] plankinfos = new PlankInfo[planks.Count];
            Console.WriteLine(plankinfos);
        }

    }
}