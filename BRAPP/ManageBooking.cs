using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental_Application
{
    public class ManageBooking
    {
        public ManageBooking(string Emails, string FullNames, string Addresses, string ZipCodes, string CityNames, string Phones, string StartDates, string EndDates, int Quantitys, int Deposits, int Rents, int TotalAmounts, int ReturnDeposits, string TypeRacings, string TypeEbikes, string TypeCitys, string TypeMountains, int CustomerIds, string TypeSelecteds)
        {
            Email = Emails;
            FullName = FullNames;
            Address = Addresses;
            ZipCode = ZipCodes;
            CityName = CityNames;
            Phone = Phones;
            StartDate = StartDates;
            EndDate = EndDates;
            Quantity = Quantitys;
            Deposit = Deposits;
            Rent = Rents;
            TotalAmount = TotalAmounts;
            ReturnDeposit = ReturnDeposits;
            TypeMountain = TypeMountains;
            TypeRacing = TypeRacings;
            TypeEBike = TypeEbikes;
            TypeCity = TypeCitys;
            CustomerId = CustomerIds;
            TypeSelected = TypeSelecteds;
        }

        public ManageBooking()
        {

        }

        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
        public string Phone { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Quantity { get; set; }
        public int Deposit { get; set; }
        public int Rent { get; set; }
        public int TotalAmount { get; set; }
        public int ReturnDeposit { get; set; }
        public string TypeMountain { get; set; }
        public string TypeRacing { get; set; }
        public string TypeCity { get; set; }
        public string TypeEBike { get; set; }
        public string TypeSelected { get; set; }
        public string FullName { get; set; }

    }
}
