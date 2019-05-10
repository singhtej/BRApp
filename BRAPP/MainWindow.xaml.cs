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

namespace Bike_Rental_Application
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
        UserControl dashboard_page = new Dashboard_Page();
        UserControl bikeonrentpage = new BikeOnRent();
        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            GridToDisplay.Children.Remove(dashboard_page);
            GridToDisplay.Children.Remove(bikeonrentpage);
            GridToDisplay.Children.Add(dashboard_page);

        }

        private void BikeOnRent_Click(object sender, RoutedEventArgs e)
        {
            GridToDisplay.Children.Remove(bikeonrentpage);
            GridToDisplay.Children.Remove(dashboard_page);

            GridToDisplay.Children.Add(bikeonrentpage);
        }
    }
}
