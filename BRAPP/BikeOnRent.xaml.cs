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
    /// Interaction logic for BikeOnRent.xaml
    /// </summary>
    public partial class BikeOnRent : UserControl
    {
        public static List<CurrentOrder> _curretnselections;
        public static int CustomerId = 0;
       

        public BikeOnRent()
        {
            InitializeComponent();
            grdSelectBike.Visibility = Visibility.Visible;
            grdCustomerDetail.Visibility = Visibility.Collapsed;
            int updateItem = 0;
            if (App._bikebookingdatastorage != null)
                updateItem = (from biker in App._bikebookingdatastorage

                              select biker.CustomerId).LastOrDefault();
            CustomerId = updateItem + 1;
        }

        public object GridToDisplay { get; private set; }

        public void DisplayCurrentSelectedBikes()
        {

            if (_curretnselections == null)
                _curretnselections = new List<CurrentOrder>();
            datgridBikeSelect.ItemsSource = null;
            datgridBikeSelect.ItemsSource = _curretnselections;
        }

        private void btnAddRecord_Click(object sender, RoutedEventArgs e)
        {
            int DepositItem = (from biker in App._biketypesdatastorage
                               where biker.Type == SelectedBikeType.Text.ToString()
                               select biker.Deposit).FirstOrDefault();

            int RentItem = (from biker in App._biketypesdatastorage
                            where biker.Type == SelectedBikeType.Text.ToString()
                            select biker.Rent).FirstOrDefault();

            int addQuantity = Convert.ToInt32(SelectedBikeQuantity.Text.ToString());
            DepositItem = DepositItem * addQuantity;
            RentItem = RentItem * addQuantity;
            string addType = SelectedBikeType.Text.ToString();
            string typemountain = "";
            string typeebike = "";
            string typecity = "";
            string typeracing = "";
            int totalquantity = 0;
            int totaldeposit = 0;
            int totalrent = 0;

            if (_curretnselections == null)
            {
                totalrent = 0;
                totalquantity = 0;
                totaldeposit = 0;
                typecity = "Not Selected";
                typeebike = "Not Selected";
                typemountain = "Not Selected";
                typeracing = "Not Selected";
            }
            else
            {
                totalrent = (from bik in _curretnselections select bik.totalRent).LastOrDefault();
                totaldeposit = (from bik in _curretnselections select bik.totalDeposit).LastOrDefault();
                totalquantity = (from bik in _curretnselections select bik.totalQuantitty).LastOrDefault();

                if ((from bik in _curretnselections where bik.TypeCity == "City Bike" select bik.TypeCity).FirstOrDefault() == null)
                {
                    typecity = "Not Selected";
                }
                else
                {
                    typecity = "City Bike";
                }
                if ((from bik in _curretnselections where bik.TypeEBike == "E-Bike" select bik.TypeEBike).FirstOrDefault() == null)
                {
                    typeebike = "Not Selected";
                }
                else
                {
                    typeebike = "E-Bike";
                }
                if ((from bik in _curretnselections where bik.TypeMountain == "Mountain Bike" select bik.TypeMountain).FirstOrDefault() == null)
                {
                    typemountain = "Not Selected";
                }
                else
                {
                    typemountain = "Mountain Bike";
                }
                if ((from bik in _curretnselections where bik.TypeRacing == "Racing Bike" select bik.TypeRacing).FirstOrDefault() == null)
                {
                    typeracing = "Not Selected";
                }
                else
                {
                    typeracing = "Racing Bike";
                }
            }
                //if ((from bik in _curretnselections where bik.TypeMountain == "City Bike" select bik.TypeCity).FirstOrDefault() == "City Bike")
                //{
                //    MessageBox.Show("This Bike Type already selected, please select another bike type.", "Error!!", MessageBoxButton.OKCancel);
                //}
                //else if ((from bik in _curretnselections where bik.TypeMountain == "E-Bike" select bik.TypeEBike).FirstOrDefault() == "E-Bike")
                //{
                //    MessageBox.Show("This Bike Type already selected, please select another bike type.", "Error!!", MessageBoxButton.OKCancel);
                //}
                //else if ((from bik in _curretnselections where bik.TypeMountain == "Mountain Bike" select bik.TypeMountain).FirstOrDefault() == "Mountain Bike")
                //{
                //    MessageBox.Show("This Bike Type already selected, please select another bike type.", "Error!!", MessageBoxButton.OKCancel);
                //}
                //else if ((from bik in _curretnselections where bik.TypeMountain == "Racing Bike" select bik.TypeRacing).FirstOrDefault() == "Racing Bike")
                //{
                //    MessageBox.Show("This Bike Type already selected, please select another bike type.", "Error!!", MessageBoxButton.OKCancel);
                //}
                //else
                //{
                    

                   
                //}


                if (addType == "Mountain Bike")
                {

                    CurrentOrder datastoring = new CurrentOrder()
                    {
                        Quantity = addQuantity,
                        Deposit = DepositItem,
                        Rent = RentItem,
                        TypeSelected = addType,
                        TypeMountain = addType,
                        TypeRacing = typeracing,
                        TypeEBike = typeebike,
                        TypeCity = typecity,
                        totalDeposit = totaldeposit + DepositItem,
                        totalQuantitty = totalquantity + addQuantity,
                        totalRent = totalrent + RentItem
                    };
                    if (_curretnselections != null)
                        _curretnselections.Add(datastoring);
                    else
                        _curretnselections = new List<CurrentOrder> { datastoring };

                }
                else if (addType == "Racing Bike")
                {
                    CurrentOrder datastoring = new CurrentOrder()
                    {
                        Quantity = addQuantity,
                        Deposit = DepositItem,
                        Rent = RentItem,
                        TypeSelected = addType,
                        TypeMountain = typemountain,
                        TypeRacing = addType,
                        TypeEBike = typeebike,
                        TypeCity = typecity,
                        totalDeposit = totaldeposit + DepositItem,
                        totalQuantitty = totalquantity + addQuantity,
                        totalRent = totalrent + RentItem
                    };

                    if (_curretnselections != null)
                        _curretnselections.Add(datastoring);
                    else
                        _curretnselections = new List<CurrentOrder> { datastoring };


                }
                else if (addType == "E-Bike")
                {
                    CurrentOrder datastoring = new CurrentOrder()
                    {
                        Quantity = addQuantity,
                        Deposit = DepositItem,
                        Rent = RentItem,
                        TypeSelected = addType,
                        TypeMountain = typemountain,
                        TypeRacing = typeracing,
                        TypeEBike = addType,
                        TypeCity = typecity,
                        totalDeposit = totaldeposit + DepositItem,
                        totalQuantitty = totalquantity + addQuantity,
                        totalRent = totalrent + RentItem
                    };

                    if (_curretnselections != null)
                        _curretnselections.Add(datastoring);
                    else
                        _curretnselections = new List<CurrentOrder> { datastoring };


                }
                else if (addType == "City Bike")
                {

                    CurrentOrder datastoring = new CurrentOrder()
                    {
                        Quantity = addQuantity,
                        Deposit = DepositItem,
                        Rent = RentItem,
                        TypeSelected = addType,
                        TypeMountain = typemountain,
                        TypeRacing = typeracing,
                        TypeEBike = typeebike,
                        TypeCity = addType,
                        totalDeposit = totaldeposit + DepositItem,
                        totalQuantitty = totalquantity + addQuantity,
                        totalRent = totalrent + RentItem
                    };

                    if (_curretnselections != null)
                        _curretnselections.Add(datastoring);
                    else
                        _curretnselections = new List<CurrentOrder> { datastoring };
                }

                DisplayCurrentSelectedBikes();
            
        }

        public void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            if(dtpckStartDate.Text != "" && dtpckEndDate.Text != "")
            {
                if (_curretnselections != null)
                {
                    var updateDatesinList = (from bik in _curretnselections
                                             select bik);
                    updateDatesinList
                   .Where(bik => bik.endDate == null & bik.startDate == null)
                   .ToList().ForEach(bik =>
                   {
                       bik.startDate = dtpckStartDate.Text;
                       bik.endDate = dtpckEndDate.Text;
        
                   });
                    grdSelectBike.Visibility = Visibility.Collapsed;
                    grdCustomerDetail.Visibility = Visibility.Visible;
                    var bikesDetail = (from biker in App._bikebookingdatastorage
                                       where biker.CustomerId == CustomerId
                                       select biker);

                    ManageBooking datastore = new ManageBooking
                    {
                        CustomerId = CustomerId,
                        Deposit = (from bik in _curretnselections select bik.totalDeposit).LastOrDefault(),
                        TypeCity = (from bik in _curretnselections select bik.TypeCity).LastOrDefault(),
                        TypeMountain = (from bik in _curretnselections select bik.TypeMountain).LastOrDefault(),
                        TypeRacing = (from bik in _curretnselections select bik.TypeRacing).LastOrDefault(),
                        TypeEBike = (from bik in _curretnselections select bik.TypeEBike).LastOrDefault(),
                        ReturnDeposit = (from bik in _curretnselections select bik.totalDeposit).LastOrDefault(),
                        //ReturnDeposit = 30,
                        EndDate = dtpckEndDate.Text,
                        Quantity = (from bik in _curretnselections select bik.totalQuantitty).LastOrDefault(),
                        Rent = (from bik in _curretnselections select bik.totalRent).LastOrDefault(),
                        StartDate = dtpckStartDate.Text,
                        //Address = "Hermann Str 5",
                        TotalAmount = (from bik in _curretnselections select bik.totalDeposit).LastOrDefault() + (from bik in _curretnselections select bik.totalRent).LastOrDefault()
                    };
                    App._bikebookingdatastorage.Add(datastore);
                    StorageClass.StoreXML<List<ManageBooking>>("BikeBookingManager.xml", App._bikebookingdatastorage);
                    DisplayRentedBike();
                }
            }else
            {
                    MessageBox.Show("Please Select Start Date and End Date.", "Error!!", MessageBoxButton.OKCancel);
            }
            
            
            

        }
        public void DisplayRentedBike()
        {
            if (_curretnselections == null)
                _curretnselections = new List<CurrentOrder>();
            datgridBikeOrder.ItemsSource = _curretnselections;

            App._bikebookingdatastorage = StorageClass.ReadXML<List<ManageBooking>>("BikeBookingManager.xml");
            if (App._bikebookingdatastorage == null)
                App._bikebookingdatastorage = new List<ManageBooking>();
            txtboxTotalAmount.Text = (from bik in App._bikebookingdatastorage where bik.CustomerId == CustomerId select bik.TotalAmount).LastOrDefault().ToString();
            //datgridBikeOrder.ItemsSource = App._bikebookingdatastorage;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Btn_Order(object sender, RoutedEventArgs e)
        {
            
        }
        
        private void ButtonOrderNow_Click(object sender, RoutedEventArgs e)
        {

            
               var bikesDetails = (from biker in App._bikebookingdatastorage
                                where biker.CustomerId == CustomerId
                                select biker);

                    bikesDetails.Where(bike => bike.CustomerId == CustomerId)
                               .ToList().ForEach(bike =>
                               {
                                   bike.Email = Email.Text;
                                   bike.FullName = FullName.Text;
                                   bike.Address = Address.Text;
                                   bike.ZipCode = ZipCode.Text;
                                   bike.CityName = City.Text;
                                   bike.Phone = Phone.Text;
                                   
                                   MessageBox.Show("Your Booking is Saved!", "Alert!!!");
                                   Email.Text = "";
                                   FullName.Text = "";
                                   Address.Text = "";
                                   ZipCode.Text = "";
                                   City.Text = "";
                                   Phone.Text = "";
                                   txtboxTotalAmount.Text = "";
                                   _curretnselections = new List<CurrentOrder>();
                                   datgridBikeOrder.ItemsSource = null;
                               });
                    StorageClass.StoreXML<List<ManageBooking>>("BikeBookingManager.xml", App._bikebookingdatastorage);
            var updateItem = (from biker in App._bikedatastorage
                              select biker);
            updateItem
            .Where(exp => exp.RentedBike == exp.RentedBike)
            .ToList().ForEach(exp =>
            {
                exp.RentedBike += 1;
                exp.AvailableBike -= 1;
            });
            StorageClass.StoreXML<List<ManageBike>>("BikeManager.xml", App._bikedatastorage);

        }

        private void ButtonBackToList_Click(object sender, RoutedEventArgs e)
        {
            grdSelectBike.Visibility = Visibility.Visible;
            grdCustomerDetail.Visibility = Visibility.Collapsed;
        }
    }
}
