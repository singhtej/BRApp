using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Bike_Rental_Application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static List<ManageBike> _bikedatastorage;
        public static List<ManageBikeTypes> _biketypesdatastorage;
        public static List<ManageBooking> _bikebookingdatastorage;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            
            _bikedatastorage = StorageClass.ReadXML<List<ManageBike>>("BikeManager.xml");
            if (_bikedatastorage == null)
                _bikedatastorage = new List<ManageBike>();

            _bikebookingdatastorage = StorageClass.ReadXML<List<ManageBooking>>("BikeBookingManager.xml");
            if (_bikebookingdatastorage == null)
                _bikebookingdatastorage = new List<ManageBooking>();

            _biketypesdatastorage = StorageClass.ReadXML<List<ManageBikeTypes>>("BikeTypeManager.xml");
            if (_biketypesdatastorage == null)
                _biketypesdatastorage = new List<ManageBikeTypes>();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {


        }
    }
}
