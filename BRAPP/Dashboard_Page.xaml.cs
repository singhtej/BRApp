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
    /// Interaction logic for Dashboard_Page.xaml
    /// </summary>
    public partial class Dashboard_Page : UserControl
    {
        public static object deletebikebookingdatastorage;
        Label rentedBikes = new Label();
        Label availableBikes = new Label();

        public Dashboard_Page()
        {
            InitializeComponent();

            Label totalBikes = new Label();
            int totalbike = 0;

            if (App._bikedatastorage != null)
                totalbike = (from bike in App._bikedatastorage
                             select bike.TotalBike).FirstOrDefault();
            string totalBiketoDisplay = "Total Bikes " + Convert.ToString(totalbike);
            totalBikes.Content = totalBiketoDisplay;
            totalBikes.Background = Brushes.SkyBlue;
            
            totalBikes.FontSize = 16;
            totalBikes.FontStyle = FontStyles.Normal;
            totalBikes.FontWeight = FontWeights.ExtraBold;
            GridDashboardDisplay.Children.Add(totalBikes);
            Grid.SetRow(totalBikes, 0);

            availableBikes.MouseDown += AvailableBikes_MouseDown;
            int availableBike = 0;
            if (App._bikedatastorage != null)
                availableBike = (from bike in App._bikedatastorage
                                 select bike.AvailableBike).FirstOrDefault();

            string availableBiketoDisplay = "Available Bikes "+ Convert.ToString(availableBike);
            availableBikes.Content = availableBiketoDisplay;
            availableBikes.ToolTip = "Type of Available Bike in Details";
            availableBikes.Background = Brushes.Transparent;
            availableBikes.FontSize = 16;
            availableBikes.BorderBrush = Brushes.Black;
            availableBikes.BorderThickness = new Thickness(1);
            availableBikes.FontStyle = FontStyles.Normal;
            availableBikes.FontWeight = FontWeights.ExtraBold;
            GridDashboardDisplay.Children.Add(availableBikes);
            Grid.SetRow(availableBikes, 1);
            rentedBikes.MouseDown += RentedBikes_MouseDown;
            int rentedBike = 0;

            if (App._bikedatastorage != null)
                rentedBike = (from bike in App._bikedatastorage
                              select bike.RentedBike).FirstOrDefault();

            string rentedBiketoDisplay = "Rented Bikes " + Convert.ToString(rentedBike);
            rentedBikes.Content = rentedBiketoDisplay;
            rentedBikes.ToolTip = "Rented Bikes Records in Details";
            rentedBikes.Background = Brushes.Snow;
            rentedBikes.BorderBrush = Brushes.Black;
            rentedBikes.BorderThickness = new Thickness(1);
            rentedBikes.FontSize = 16;
            rentedBikes.FontStyle = FontStyles.Normal;
            rentedBikes.FontWeight = FontWeights.ExtraBold;
            GridDashboardDisplay.Children.Add(rentedBikes);
            Grid.SetRow(rentedBikes, 2);

        }

        private void AvailableBikes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GridDisplayRentedBikes.Visibility = Visibility.Collapsed;

            var totalRented = (from bikesrented in App._bikebookingdatastorage
                               select bikesrented);
            List<string> allBikes = (from bikesTypeAvailable in App._biketypesdatastorage
                                     select bikesTypeAvailable.Type).ToList();

            var allBikess = (from bikesTypeAvailable in App._biketypesdatastorage
                             select bikesTypeAvailable);

            var typeBikeDictionary = new Dictionary<string, int>();

            allBikess.Where(exp => exp.Type == exp.Type)
                            .ToList().ForEach(exp =>
                            {
                                typeBikeDictionary.Add(exp.Type, exp.Quantity);
                            });

            string bikeTypeName = "";

            foreach (string bike in allBikes)
            {
                if (bike == "Racing Bike")
                {
                    totalRented.Where(exp => exp.TypeRacing == bike)
                            .ToList().ForEach(exp =>
                            {
                                if (typeBikeDictionary.Keys.Contains(exp.TypeRacing))
                                {
                                    if (bikeTypeName == "")
                                    {
                                        bikeTypeName = exp.TypeRacing;
                                        typeBikeDictionary[exp.TypeRacing] -= 1;
                                    }
                                    else
                                    {
                                        if (bikeTypeName == exp.TypeRacing)
                                        {
                                            typeBikeDictionary[exp.TypeRacing] -= 1;
                                        }
                                        else
                                        {
                                            typeBikeDictionary[exp.TypeRacing] -= 1;
                                            bikeTypeName = exp.TypeRacing;
                                        }
                                    }
                                }


                            });
                }

                else if (bike == "E-Bike")
                {
                    totalRented.Where(exp => exp.TypeEBike == bike)
                               .ToList().ForEach(exp =>
                               {
                                   if (typeBikeDictionary.Keys.Contains(exp.TypeEBike))
                                   {
                                       if (bikeTypeName == "")
                                       {
                                           bikeTypeName = exp.TypeEBike;
                                           typeBikeDictionary[exp.TypeEBike] -= 1;
                                       }
                                       else
                                       {
                                           if (bikeTypeName == exp.TypeEBike)
                                           {
                                               typeBikeDictionary[exp.TypeEBike] -= 1;
                                           }
                                           else
                                           {
                                               typeBikeDictionary[exp.TypeEBike] -= 1;
                                               bikeTypeName = exp.TypeEBike;
                                           }
                                       }
                                   }


                               });
                }

                else if (bike == "City Bike")
                {
                    totalRented.Where(exp => exp.TypeCity == bike)
                               .ToList().ForEach(exp =>
                               {
                                   if (typeBikeDictionary.Keys.Contains(exp.TypeCity))
                                   {
                                       if (bikeTypeName == "")
                                       {
                                           bikeTypeName = exp.TypeCity;
                                           typeBikeDictionary[exp.TypeCity] -= 1;
                                       }
                                       else
                                       {
                                           if (bikeTypeName == exp.TypeCity)
                                           {
                                               typeBikeDictionary[exp.TypeCity] -= 1;
                                           }
                                           else
                                           {
                                               typeBikeDictionary[exp.TypeCity] -= 1;
                                               bikeTypeName = exp.TypeCity;
                                           }
                                       }
                                   }


                               });
                }

                else if (bike == "Mountain Bike")
                {
                    totalRented.Where(exp => exp.TypeMountain == bike)
                               .ToList().ForEach(exp =>
                               {
                                   if (typeBikeDictionary.Keys.Contains(exp.TypeMountain))
                                   {
                                       if (bikeTypeName == "")
                                       {
                                           bikeTypeName = exp.TypeMountain;
                                           typeBikeDictionary[exp.TypeMountain] -= 1;
                                       }
                                       else
                                       {
                                           if (bikeTypeName == exp.TypeMountain)
                                           {
                                               typeBikeDictionary[exp.TypeMountain] -= 1;
                                           }
                                           else
                                           {
                                               typeBikeDictionary[exp.TypeMountain] -= 1;
                                               bikeTypeName = exp.TypeMountain;
                                           }
                                       }
                                   }


                               });
                }

            }

            int totalBike = (from bikesAvailable in App._biketypesdatastorage
                             select bikesAvailable.Quantity).FirstOrDefault();

            datgridBikeAvailable.ItemsSource = typeBikeDictionary;
            datgridBikeAvailable.Visibility = Visibility.Visible;
            ButtonReturnBike.Visibility = Visibility.Collapsed;
        }

        private void RentedBikes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            datgridBikeAvailable.Visibility = Visibility.Collapsed;
            datgridBikeRented.ItemsSource = App._bikebookingdatastorage;

            GridDisplayRentedBikes.Visibility = Visibility.Visible;
            ButtonReturnBike.Visibility = Visibility.Collapsed;
            TextboxSearch.Visibility = Visibility.Visible;
            LabelboxSearch.Visibility = Visibility.Visible;

        }

        private void TextboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextboxSearch.Text == null || TextboxSearch.Text.Equals(""))
            {
                datgridBikeRented.ItemsSource = App._bikebookingdatastorage;
            }
            else
            {
                datgridBikeRented.SelectedItem = null;
                var filterResult = (
                    from bikeDetails in App._bikebookingdatastorage
                    where (bikeDetails.Phone.ToString().
                        StartsWith(TextboxSearch.Text, StringComparison.InvariantCultureIgnoreCase)
                        || Convert.ToString(bikeDetails.EndDate).StartsWith(TextboxSearch.Text,
                        StringComparison.InvariantCultureIgnoreCase)
                        || bikeDetails.FullName.StartsWith(TextboxSearch.Text,
                        StringComparison.InvariantCultureIgnoreCase)
                        )
                    select bikeDetails);
                datgridBikeRented.ItemsSource = filterResult;
            }
            ButtonReturnBike.Visibility = Visibility.Collapsed;

        }
        public void DisplayRentedBike()
        {
            App._bikebookingdatastorage = StorageClass.ReadXML<List<ManageBooking>>("BikeBookingManager.xml");
            if (App._bikebookingdatastorage == null)
                App._bikebookingdatastorage = new List<ManageBooking>();

            datgridBikeRented.ItemsSource = App._bikebookingdatastorage;
        }

        public void DisplayAvailableBike()
        {
            App._bikedatastorage = StorageClass.ReadXML<List<ManageBike>>("BikeManager.xml");
            if (App._bikedatastorage == null)
                App._bikedatastorage = new List<ManageBike>();

            datgridBikeRented.ItemsSource = App._bikebookingdatastorage;

            int availableBike = (from bike in App._bikedatastorage
                                 select bike.AvailableBike).FirstOrDefault();
            string availableBiketoDisplay = "Available Bike " + Convert.ToString(availableBike);

            availableBikes.Content = availableBiketoDisplay;

            int rentedBike = (from bike in App._bikedatastorage
                              select bike.RentedBike).FirstOrDefault();
            string rentedBiketoDisplay = "Rented Bike " + Convert.ToString(rentedBike);

            rentedBikes.Content = rentedBiketoDisplay;
        }

        private void ButtonReturnBike_Click(object sender, RoutedEventArgs e)
        {
            var deleterecord = App._bikebookingdatastorage;
            deleterecord.Remove(deletebikebookingdatastorage as ManageBooking);
            StorageClass.StoreXML<List<ManageBooking>>("BikeBookingManager.xml", deleterecord);
            DisplayRentedBike();

            var updateItem = (from biker in App._bikedatastorage
                              select biker);
            updateItem
            .Where(exp => exp.RentedBike == exp.RentedBike)
            .ToList().ForEach(exp =>
            {
                exp.RentedBike -= 1;
                exp.AvailableBike += 1;
            });
            StorageClass.StoreXML<List<ManageBike>>("BikeManager.xml", App._bikedatastorage);

            DisplayAvailableBike();

            TextboxSearch.Visibility = Visibility.Visible;
            LabelboxSearch.Visibility = Visibility.Visible;
        }

        private void DataGridBikeReturn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int filterIdValue = 0;
                int totalItems = (from biker in App._bikebookingdatastorage
                                  select biker).Count();

                if (totalItems >= filterIdValue || datgridBikeRented.SelectedItem != null)
                {
                    if (datgridBikeRented.SelectedItem != null)
                    {
                        object item = datgridBikeRented.SelectedItem;
                        string ID = (datgridBikeRented.SelectedCells[0].Column.GetCellContent(item)
                            as TextBlock).Text;

                        var itemToUpdate = (from biker in App._bikebookingdatastorage
                                            where (biker.FullName == ID)
                                            select biker);

                        itemToUpdate.Where(exp => exp.FullName == ID)
                            .ToList().ForEach(exp =>
                            {
                                ButtonReturnBike.Visibility = Visibility.Visible;
                                TextboxSearch.Visibility = Visibility.Collapsed;
                                LabelboxSearch.Visibility = Visibility.Collapsed;
                                deletebikebookingdatastorage = exp;
                            });
                    }
                }
            }
            catch (System.IndexOutOfRangeException es)
            {
                MessageBox.Show(es.Message);
                // Set IndexOutOfRangeException to the new exception's InnerException.
                throw new System.ArgumentOutOfRangeException("Index parameter is out of range.", es);
            }
        }
    }
}
