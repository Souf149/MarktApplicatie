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
using System.Windows.Shapes;

namespace MarktApplicatie
{
    /// <summary>
    /// Interaction logic for statoftheday.xaml
    /// </summary>
    public partial class statoftheday : Window
    {
        public statoftheday()
        {
            InitializeComponent();
        }

        private void Sluiten(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }
    }
}
