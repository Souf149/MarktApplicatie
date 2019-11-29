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
using System.Windows.Threading;

namespace MarktApplicatie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer loopTimer;
        public const int FPS = 30;

        public MainWindow()
        {
            InitializeComponent();

            //  DispatcherTimer setup
            loopTimer = new DispatcherTimer();
            loopTimer.Tick += new EventHandler(Loop);
            loopTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000/FPS);
            loopTimer.Start();


        }

        private void Loop(Object sender, EventArgs e)
        {
            btn.Content += "a";
        }

        

        private void OnClick_newComposition(object sender, MouseButtonEventArgs e) {
            EditKraam editkraam = new EditKraam();
            editkraam.Show();
            this.Close();

        }
        private void OnClick_oldComposition(object sender, MouseButtonEventArgs e) {
            OudeComposities oudecompo = new OudeComposities();
            oudecompo.Show();
            this.Close();
        }

        private void OnClick_statistics(object sender, MouseButtonEventArgs e) {
            statistieken statistics = new statistieken();
            statistics.Show();
            this.Close();

        }

        private void OnClick_settings(object sender, MouseButtonEventArgs e) {

        }

    }
}
