using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace MarktApplicatie
{
    public partial class OudeComposities : Window
    {


        public int i = 0;
        string[] composition_names;

        public OudeComposities()
        {
            InitializeComponent();

            


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


            UpdateList();

            if (composition_names.Length < 1) {
                MessageBox.Show("Je moet eerst een compositie opslaan!");
            }

            if (i == 0)
            {
                sorttxt.Text = "Sorteer [A-Z]";

            }
        }

        

        private void AddListViewItem(string filename) {

            // add item to the list if the filename ends with .json
            TextBlock b = new TextBlock() {
                Text = filename,
                FontSize = 24
            };

            listView.Items.Add(b);

        }


        
        private void ListView_onclick(object sender, MouseButtonEventArgs e)
        {
            if (listView.SelectedIndex < 0) {
                return;
            }

            TextBlock txt = (TextBlock)listView.SelectedItem;
            string img_filename = txt.Text + ".png";

        

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = new Uri(SoufTools.compositions_path + img_filename);
            image.DecodePixelWidth = (int)canvas.ActualWidth;
            image.EndInit();

            img_preview.Source = image;


        }

        private void onClick_homepage(object sender, RoutedEventArgs e) {
            MainWindow home = new MainWindow();
            home.Show();
            Close();
        }

        private void statistic(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedIndex < 0)
            {
                MessageBox.Show("Kies eerst een compositie!", "Zie statistiek", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            new statistieken_yasin().Show();
            this.Close();
        }

        public void StartSketch(object sender, RoutedEventArgs e) {

            if (listView.SelectedIndex < 0) {
                return;
            }

            string selected_file_name = composition_names[listView.SelectedIndex];

            string plankinfo = File.ReadAllText(Path.Combine(SoufTools.compositions_path, selected_file_name + ".json"));
            PlankInfo[] result = JsonConvert.DeserializeObject<PlankInfo[]>(plankinfo);

            EditKraam editkraam = new EditKraam();

            if (result != null) {
                foreach (PlankInfo p in result) {
                    editkraam.Add_plank(p.X, p.Y, p.Width, p.Height);
                }
            }

            editkraam.Show();
            Close();
        }

      


        public void btnEditTitle_Click(object sender, RoutedEventArgs e) {

            int selected_index = listView.SelectedIndex;
            if (selected_index < 0) {
                return;
            }

            save_popup popup = new save_popup();

            if (popup.ShowDialog() == true) {
                string compositions_path = SoufTools.compositions_path;

                string old_filename = composition_names[selected_index];
                string new_filename = popup.FileName;

                string old_path = Path.Combine(compositions_path, old_filename);
                string new_path = Path.Combine(compositions_path, new_filename);

                
                File.Move(old_path + ".png", new_path + ".png");
                File.Move(old_path + ".json", new_path + ".json");

                UpdateList();
            }
        }

        private void UpdateList() {

            listView.Items.Clear();

            string[] files = SoufTools.GetAllCompositions();
            composition_names = new string[files.Length / 2];

            
            for (int i = 0, j = 0; i < files.Length; i++)
            {
                if(Path.GetExtension(files[i]) == ".json")
                {
                    composition_names[j++] = Path.GetFileNameWithoutExtension(files[i]);
                }
            }
            
            // for every file get the filename and add it to 
            foreach (string name in composition_names) {
                    AddListViewItem(name);
            }


        }


        private void Sort(object sender, RoutedEventArgs e)
        {

            i += 1;
            if (i == 2)
            {
                i = 0;
                sorttxt.Text = "Sorteer [A-Z]";
                listView.Items.SortDescriptions.Clear();
                // sorteer z-a
            }

            if (i == 1)
            {
                sorttxt.Text = "Sorteer [Z-A]";
                // sorteer a-z
            }

            


        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            string inp = txtFilter.Text;
            if (inp == "")
            {
                UpdateList();
                return;
            }
            UpdateList();

            ItemCollection old_listView_list = listView.Items;
            List<string> new_listView_list = new List<string>();
            foreach (TextBlock txt_block in old_listView_list)
            {
                string txt = txt_block.Text;
                if (txt.ToLower().Contains(inp.ToLower()))
                {
                    new_listView_list.Add(txt);
                }
            }
            listView.Items.Clear();
            foreach (string txt in new_listView_list)
            {
                AddListViewItem(txt);
            }
        }


        private void OnClick_Verwijder(object sender, RoutedEventArgs e) {

            if (listView.SelectedIndex < 0) {
                return;
            }


            confirmation_popup popup = new confirmation_popup();

            if (popup.ShowDialog() == true) {
                if (popup.Confirmation) {
                    string filename = composition_names[listView.SelectedIndex];
                    File.Delete(Path.Combine(SoufTools.compositions_path, filename + ".json"));
                    File.Delete(Path.Combine(SoufTools.compositions_path, filename + ".png"));
                    img_preview.Source = new BitmapImage();
                    UpdateList();
                }
            }
        }

        
    }
}