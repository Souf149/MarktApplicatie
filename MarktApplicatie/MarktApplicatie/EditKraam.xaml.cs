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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MarktApplicatie
{
    
    public partial class EditKraam : Window
    {
        public EditKraam()
        {
            InitializeComponent();
        }

        private void onClick_homepage(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }

        private void onClick_Opslaan(object sender, MouseButtonEventArgs e)
        {

        }

        private void onClick_editbus(object sender, MouseButtonEventArgs e)
        {
            editbus editBus = new editbus();
            editBus.Show();
            this.Close();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        private void onClick_Drag(object sender, MouseButtonEventArgs e)
        {
            TextBlock r = (TextBlock)sender;
            DataObject ding = new DataObject(r.Background);
            DragDrop.DoDragDrop(r, ding, DragDropEffects.Move);
            //https://www.youtube.com/watch?v=TksMljeFaV4
        }

         

    }
}
