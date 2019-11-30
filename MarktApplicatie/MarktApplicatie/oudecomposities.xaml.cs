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
            var bitmap = new BitmapImage();
            using (var stream = new FileStream(@"..\..\Images\tab1.jpg", FileMode.Open))
            {
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();
                bitmap.Freeze(); // optional
            }

            imgPhoto.Source = bitmap;
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

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tab1.IsSelected)
            {
                if (imgPhoto == null)  
                {
                }
                else
                {
                    //this is the cause of the problem.
                    //imgPhoto.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(@"..\..\Images\tab1.jpg");
                    var bitmap = new BitmapImage();
                    using (var stream = new FileStream(@"..\..\Images\tab1.jpg", FileMode.Open))
                    {
                        bitmap.BeginInit();
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.StreamSource = stream;
                        bitmap.EndInit();
                        bitmap.Freeze(); // optional
                    }

                    imgPhoto.Source = bitmap;
                    tabName.Text = tab1.Header.ToString();

                }
            }
            else if (tab2.IsSelected)
            {
                //imgPhoto.Source = (ImageSource)new ImageSourceConverter().ConvertFrom("C:/Users/khadar/Documents/GitHub/MarktApplicatie/MarktApplicatie/MarktApplicatie/Images/tab2.jpg");
                var bitmap = new BitmapImage();
                using (var stream = new FileStream(@"..\..\Images\tab2.jpg", FileMode.Open))
                {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                    bitmap.Freeze(); // optional
                }

                imgPhoto.Source = bitmap;
                tabName.Text = tab2.Header.ToString();

            }
            else if (tab3.IsSelected)
            {

                // imgPhoto.Source = (ImageSource)new ImageSourceConverter().ConvertFrom("C:/Users/khadar/Documents/GitHub/MarktApplicatie/MarktApplicatie/MarktApplicatie/Images/tab3.jpg");
                var bitmap = new BitmapImage();
                using (var stream = new FileStream(@"..\..\Images\tab3.jpg", FileMode.Open))
                {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                    bitmap.Freeze(); // optional
                }

                imgPhoto.Source = bitmap;
                tabName.Text = tab3.Header.ToString();
            }
            else if (tab4.IsSelected)
            {
                //imgPhoto.Source = (ImageSource)new ImageSourceConverter().ConvertFrom("C:/Users/khadar/Documents/GitHub/MarktApplicatie/MarktApplicatie/MarktApplicatie/Images/tab4.jpg");
                var bitmap = new BitmapImage();
                using (var stream = new FileStream(@"..\..\Images\tab4.jpg", FileMode.Open))
                {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                    bitmap.Freeze(); // optional
                }

                imgPhoto.Source = bitmap;
                tabName.Text = tab4.Header.ToString();
            }
            else if (tab5.IsSelected)
            {
                //imgPhoto.Source = (ImageSource)new ImageSourceConverter().ConvertFrom("C:/Users/khadar/Documents/GitHub/MarktApplicatie/MarktApplicatie/MarktApplicatie/Images/tab5.jpg");
                var bitmap = new BitmapImage();
                using (var stream = new FileStream(@"..\..\Images\tab5.jpg", FileMode.Open))
                {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                    bitmap.Freeze(); // optional
                }

                imgPhoto.Source = bitmap;
                tabName.Text = tab5.Header.ToString();
            }
            else if (tab6.IsSelected)
            {
                //imgPhoto.Source = (ImageSource)new ImageSourceConverter().ConvertFrom("C:/Users/khadar/Documents/GitHub/MarktApplicatie/MarktApplicatie/MarktApplicatie/Images/tab6.jpg");
                var bitmap = new BitmapImage();
                using (var stream = new FileStream(@"..\..\Images\tab6.jpg", FileMode.Open))
                {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                    bitmap.Freeze(); // optional
                }

                imgPhoto.Source = bitmap;
                tabName.Text = tab6.Header.ToString();
            }
            else if (tab7.IsSelected)
            {
                // imgPhoto.Source = (ImageSource)new ImageSourceConverter().ConvertFrom("C:/Users/khadar/Documents/GitHub/MarktApplicatie/MarktApplicatie/MarktApplicatie/Images/tab7.jpg"); 
                var bitmap = new BitmapImage();
                using (var stream = new FileStream(@"..\..\Images\tab7.jpg", FileMode.Open))
                {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                    bitmap.Freeze(); // optional
                }

                imgPhoto.Source = bitmap;
                tabName.Text = tab7.Header.ToString();
            }
            else if (tab8.IsSelected)
            {
                //imgPhoto.Source = (ImageSource)new ImageSourceConverter().ConvertFrom("C:/Users/khadar/Documents/GitHub/MarktApplicatie/MarktApplicatie/MarktApplicatie/Images/tab8.jpg"); 
                var bitmap = new BitmapImage();
                using (var stream = new FileStream(@"..\..\Images\tab8.jpg", FileMode.Open))
                {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                    bitmap.Freeze(); // optional
                }

                imgPhoto.Source = bitmap;
                tabName.Text = tab8.Header.ToString();
            }
        }
        private void onClick_homepage(object sender, MouseButtonEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }


        public void btnLoadPlanks_Click(object sender, RoutedEventArgs e)
        {
            string plankinfo = File.ReadAllText(@"..\..\plankinfo.json");
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
        
        public void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(op.FileName);
                bitmap.CacheOption = BitmapCacheOption.None;
                bitmap.CreateOptions = BitmapCreateOptions.DelayCreation;
                bitmap.EndInit();
                imgPhoto.Source = bitmap;
            }
            Title = op.FileName;
        }
        public void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try {
                var bitmap = new Uri(Title);
                var encoder = new JpegBitmapEncoder(); // Or any other, e.g. PngBitmapEncoder for PNG.
                encoder.Frames.Add(BitmapFrame.Create(bitmap, BitmapCreateOptions.DelayCreation, BitmapCacheOption.None));
                encoder.QualityLevel = 100; // Set quality level 1-100.
                if (tab1.IsSelected)
                {
                    try
                    {
                        using (FileStream file = File.OpenWrite(@"..\..\Images\tab1.jpg"))
                        {
                            //File.Delete("C:/Users/khadar/Documents/GitHub/MarktApplicatie/MarktApplicatie/MarktApplicatie/Images/tab1.jpg");
                            encoder.Save(file);
                            MessageBox.Show("Done!");
                            file.Close();
                        }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (tab2.IsSelected)
                {
                    using (var stream = new FileStream(@"..\..\Images\tab2.jpg", FileMode.OpenOrCreate))
                    {
                        //File.Delete("C:/Users/khadar/Documents/GitHub/MarktApplicatie/MarktApplicatie/MarktApplicatie/Images/tab2.jpg");
                        encoder.Save(stream);
                        MessageBox.Show("Done!");
                        stream.Close();
                    }
                }
                else if (tab3.IsSelected)
                {
                    using (var stream = new FileStream(@"..\..\Images\tab3.jpg", FileMode.OpenOrCreate))
                    {
                        //File.Delete("C:/Users/khadar/Documents/GitHub/MarktApplicatie/MarktApplicatie/MarktApplicatie/Images/tab3.jpg");
                        encoder.Save(stream);
                        MessageBox.Show("Done!");
                        stream.Close();
                    }
                }
                else if (tab4.IsSelected)
                {
                    //File.Delete("C:/Users/khadar/Documents/GitHub/MarktApplicatie/MarktApplicatie/MarktApplicatie/Images/tab4.jpg");
                    using (var stream = new FileStream(@"..\..\Images\tab4.jpg", FileMode.OpenOrCreate))
                    {
                        encoder.Save(stream);
                        MessageBox.Show("Done!");
                        stream.Close();
                    }
                }
                else if (tab5.IsSelected)
                {
                    // File.Delete("C:/Users/khadar/Documents/GitHub/MarktApplicatie/MarktApplicatie/MarktApplicatie/Images/tab5.jpg");
                    using (var stream = new FileStream(@"..\..\Images\tab5.jpg", FileMode.OpenOrCreate))
                    {
                        encoder.Save(stream);
                        MessageBox.Show("Done!");
                        stream.Close();
                    }
                }
                else if (tab6.IsSelected)
                {
                    //File.Delete("C:/Users/khadar/Documents/GitHub/MarktApplicatie/MarktApplicatie/MarktApplicatie/Images/tab6.jpg");
                    using (var stream = new FileStream(@"..\..\Images\tab6.jpg", FileMode.OpenOrCreate))
                    {
                        encoder.Save(stream);
                        MessageBox.Show("Done!");
                        stream.Close();
                    }
                }
                else if (tab7.IsSelected)
                {
                    //File.Delete("C:/Users/khadar/Documents/GitHub/MarktApplicatie/MarktApplicatie/MarktApplicatie/Images/tab7.jpg");
                    using (var stream = new FileStream(@"..\..\Images\tab7.jpg", FileMode.OpenOrCreate))
                    {
                        encoder.Save(stream);
                        MessageBox.Show("Done!");
                        stream.Close();
                    }
                }
                else if (tab8.IsSelected)
                {
                    //File.Delete("C:/Users/khadar/Documents/GitHub/MarktApplicatie/MarktApplicatie/MarktApplicatie/Images/tab8.jpg");
                    using (var stream = new FileStream(@"..\..\Images\tab8.jpg", FileMode.Create))
                    {
                        encoder.Save(stream);
                        MessageBox.Show("Done!");
                        stream.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Choose a different file to save.");
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
