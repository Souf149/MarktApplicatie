using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace MarktApplicatie
{
    public partial class OudeComposities : Window
    {

        public OudeComposities()
        {
            InitializeComponent();
            tab1.Header = Settings1.Default.tab1Setting;
            tab2.Header = Settings1.Default.tab2Setting;
            tab3.Header = Settings1.Default.tab3Setting;
            tab4.Header = Settings1.Default.tab4Setting;
            tab5.Header = Settings1.Default.tab5Setting;
            tab6.Header = Settings1.Default.tab6Setting;
            tab7.Header = Settings1.Default.tab7Setting;
            tab8.Header = Settings1.Default.tab8Setting;
            tabName.Text = Settings1.Default.tab1Setting;
        }

        public void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tab1.IsSelected)
            {
                tabName.Text = tab1.Header.ToString();   
            }
            else if (tab2.IsSelected)
            {
                tabName.Text = tab2.Header.ToString();
            }
            else if (tab3.IsSelected)
            {
                tabName.Text = tab3.Header.ToString();
            }
            else if (tab4.IsSelected)
            {
                tabName.Text = tab4.Header.ToString();
            }
            else if (tab5.IsSelected)
            {
                tabName.Text = tab5.Header.ToString();
            }
            else if (tab6.IsSelected)
            {
                tabName.Text = tab6.Header.ToString();
            }
            else if (tab7.IsSelected)
            {
                tabName.Text = tab7.Header.ToString();
            }
            else if (tab8.IsSelected)
            {
                tabName.Text = tab8.Header.ToString();
            }
        }

        private void btngotocomp(object sender, MouseButtonEventArgs e)
        {

            if (tab1.IsSelected)
            {
                btnLoadPlanks_Click(1);
            }
            else if (tab2.IsSelected)
            {
                btnLoadPlanks_Click(2);
            }
            else if (tab3.IsSelected)
            {
                btnLoadPlanks_Click(3);
            }
            else if (tab4.IsSelected)
            {
                btnLoadPlanks_Click(4);
            }
            else if (tab5.IsSelected)
            {
                btnLoadPlanks_Click(5);
            }
            else if (tab6.IsSelected)
            {
                btnLoadPlanks_Click(6);
            }
            else if (tab7.IsSelected)
            {
                btnLoadPlanks_Click(7);
            }
            else if (tab8.IsSelected)
            {
                btnLoadPlanks_Click(8);
            }
        }
        private void onClick_homepage(object sender, MouseButtonEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }


        public void btnLoadPlanks_Click(int valuetab)
        {
            if (valuetab == 1)
            {
                string plankinfo = File.ReadAllText(@"..\..\json\plankinfo.json");
                PlankInfo[] result = JsonConvert.DeserializeObject<PlankInfo[]>(plankinfo);
                Console.WriteLine(result);

                EditKraam ek = new EditKraam();

                foreach (PlankInfo p in result)
                {
                    ek.Add_plank(p.X, p.Y, p.Width, p.Height);
                }

                ek.Show();
                Close();
            }
            else
            {
                string plankinfo = File.ReadAllText(@"..\..\json\plankinfo" + valuetab + ".json");
                PlankInfo[] result = JsonConvert.DeserializeObject<PlankInfo[]>(plankinfo);
                Console.WriteLine(result);

                EditKraam ek = new EditKraam();

                foreach (PlankInfo p in result)
                {
                    ek.Add_plank(p.X, p.Y, p.Width, p.Height);
                }

                ek.Show();
                Close();
            }
        }


        public void btnEditTitle_Click(object sender, RoutedEventArgs e)
        {
            if (tab1.IsSelected)
            {

                //tab1.Header = tabName.Text;

                Settings1.Default.tab1Setting = tabName.Text;
                tab1.Header = Settings1.Default.tab1Setting;
                Settings1.Default.Save();


            }

            else if (tab2.IsSelected)
            {
                Settings1.Default.tab2Setting = tabName.Text;
                tab2.Header = Settings1.Default.tab2Setting;
                Settings1.Default.Save();

            }
            else if (tab3.IsSelected)
            {

                Settings1.Default.tab3Setting = tabName.Text;
                tab3.Header = Settings1.Default.tab3Setting;
                Settings1.Default.Save();
            }
            else if (tab4.IsSelected)
            {
                Settings1.Default.tab4Setting = tabName.Text;
                tab4.Header = Settings1.Default.tab4Setting;
                Settings1.Default.Save();
            }
            else if (tab5.IsSelected)
            {
                Settings1.Default.tab5Setting = tabName.Text;
                tab5.Header = Settings1.Default.tab5Setting;
                Settings1.Default.Save();
            }
            else if (tab6.IsSelected)
            {
                Settings1.Default.tab6Setting = tabName.Text;
                tab6.Header = Settings1.Default.tab6Setting;
                Settings1.Default.Save();
            }
            else if (tab7.IsSelected)
            {
                Settings1.Default.tab7Setting = tabName.Text;
                tab7.Header = Settings1.Default.tab7Setting;
                Settings1.Default.Save();
            }
            else if (tab8.IsSelected)
            {
                Settings1.Default.tab8Setting = tabName.Text;
                tab8.Header = Settings1.Default.tab8Setting;
                Settings1.Default.Save();
            }

        }
    }
}
