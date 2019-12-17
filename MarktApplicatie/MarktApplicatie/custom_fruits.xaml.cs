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
    /// Interaction logic for custom_fruits.xaml
    /// </summary>
    public partial class custom_fruits : Window
    {
        public custom_fruits()
        {
            InitializeComponent();

           /*
            if (Settings1.Default.Darkmode == true)
            {
                list_view.Background = new SolidColorBrush(Colors.Black);
                list_view.Foreground = new SolidColorBrush(Colors.White);
            }

            if (Settings1.Default.Darkmode == false)
            {
                list_view.Background = new SolidColorBrush(Colors.White);
                list_view.Foreground = new SolidColorBrush(Colors.Black);
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



            // load fruits from file and split it into each fruit with their respective color.
            string data = File.ReadAllText(SoufTools.custom_fruit_path);
            string[] data_fruits = data.Split(';');


            foreach(string fruit in data_fruits)
            {
                // if you reached the end of the line
                if(fruit.Length == 0)
                {
                    break;
                }

                // every fruit with their color gets split and combined into a new item
                string[] d = fruit.Split('|');
                CreateNewItem(d[0], d[1]);
            }

        }

        private void Add_new_fruit(object sender, MouseButtonEventArgs e)
        {
            add_new_fruit dialog = new add_new_fruit();
            if (dialog.ShowDialog() == true) {

                

                string[] rgb = new string[] {
                    dialog.Inp_red,
                    dialog.Inp_blue,
                    dialog.Inp_green
                };

                string hexColor = "#";
                for(int i = 0; i < rgb.Length; i++) {
                    string hex = SoufTools.DecimalToHexadecimal(Convert.ToInt32(rgb[i]));

                    // low numbers only have 1 digit
                    if (hex.Length < 2) {
                        hex += "0";
                    }


                    hexColor += hex;
                }

                CreateNewItem(dialog.Inp_naam, hexColor);

            }
        }

        private void CreateNewItem(string name_, string color_)
        {
            int id = list_view.Items.Count;

            StackPanel stack = new StackPanel();

            TextBlock txt_id = new TextBlock();
            txt_id.Text = id.ToString();

            TextBlock txt_name = new TextBlock();
            txt_name.Text = name_;

            TextBlock txt_color = new TextBlock();
            txt_color.Text = color_;

            Button btn_button = new Button();
            btn_button.Content = "delete";
            

            btn_button.PreviewMouseLeftButtonDown += Remove_item;


            stack.Children.Add(txt_id);
            stack.Children.Add(txt_name);
            stack.Children.Add(txt_color);
            stack.Children.Add(btn_button);


            list_view.Items.Add(stack);
        }


        void Remove_item(object sender, RoutedEventArgs e) {

            // Remove stackpanel from the button that sent it
            Button btn = (Button)sender;
            StackPanel sp = (StackPanel)btn.Parent;
            ListView lv = (ListView)sp.Parent;
            TextBlock txt = (TextBlock)sp.Children[0];
            int id = Convert.ToInt32(txt.Text);
            if (lv.Items.Count > 1) {
                lv.Items.RemoveAt(id);
            }
            else {
                MessageBox.Show("Je mag niet alles verwijderen");
            }

            // re-setting all id numbers
            for(int i = 0; i < lv.Items.Count; i++) {
                StackPanel inner_sp = (StackPanel)lv.Items[i];
                TextBlock inner_txt = (TextBlock)inner_sp.Children[0];
                inner_txt.Text = i.ToString();
            }
            

        }

        private void Quit_and_save(object sender, MouseButtonEventArgs e) {
            string data = "";

            foreach(StackPanel sp in list_view.Items) {
                TextBlock txt_naam = (TextBlock)sp.Children[1];
                TextBlock txt_color = (TextBlock)sp.Children[2];

                data += $"{txt_naam.Text}|{txt_color.Text};";


            }

            data = data.Remove(data.Length - 1);
            File.WriteAllText(SoufTools.custom_fruit_path, data);

            DialogResult = true;
        }
    }
}
