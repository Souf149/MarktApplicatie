using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using static MarktApplicatie.statoftheday;

namespace MarktApplicatie
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        

        private void Application_Startup(object sender, StartupEventArgs e)
        {

           
            if (MarktApplicatie.Properties.Settings.Default.Message == true)
            {
                new MainWindow().Show();
            }
          
            if (MarktApplicatie.Properties.Settings.Default.Message == false)
            {
                new statoftheday().Show();
                
            }
          
               

        }

    }
}
