using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MarktApplicatie
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            
            
            MessageBox.Show("tip van de dag is het bekijken van oude composities in het laadscherm", "Tip van de dag");
            



            new MainWindow().Show();
            

        }

    }
}
