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
    /// Interaction logic for custom_fruits.xaml
    /// </summary>
    public partial class custom_fruits : Window
    {
        public custom_fruits()
        {
            InitializeComponent();

            CreateNewItem("Hello", "haa");

        }

        private void Add_new_fruit(object sender, MouseButtonEventArgs e)
        {

        }

        private void CreateNewItem(string name_, string color_)
        {
            StackPanel stack = new StackPanel();

            TextBlock name = new TextBlock
            {
                Text = name_
            };
            TextBlock color = new TextBlock
            {
                Text = color_
            };


            stack.Children.Add(name);
            stack.Children.Add(color);


            list_view.Items.Add(stack);
        }
    }
}
