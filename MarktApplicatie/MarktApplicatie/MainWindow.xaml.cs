﻿using System;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void onClick_newComposition(object sender, MouseButtonEventArgs e) {
            EditKraam editkraam = new EditKraam();
            editkraam.Show();
            this.Close();

        }
        private void onClick_oldComposition(object sender, MouseButtonEventArgs e) {

        }
        private void onClick_statistics(object sender, MouseButtonEventArgs e) {

        }
        private void onClick_settings(object sender, MouseButtonEventArgs e) {

        }

    }
}
