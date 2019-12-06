using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        string[] composition_names;

        public OudeComposities()
        {
            InitializeComponent();

            UpdateList();

            if (composition_names.Length < 1) {
                MessageBox.Show("Je moet eerst een compositie opslaan!");
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
            image.EndInit();

            img_preview.Source = image;


        }

        private void onClick_homepage(object sender, RoutedEventArgs e) {
            MainWindow home = new MainWindow();
            home.Show();
            Close();
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