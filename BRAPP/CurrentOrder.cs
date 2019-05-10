using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental_Application
{
    public class CurrentOrder
    {
        public CurrentOrder(int Quantitys, int totalDeposits, int totalQuantittys, int totalRents, int Deposits, int Rents, string TypeRacings, string TypeEbikes, string TypeCitys, string TypeMountains, string TypeSelecteds, string endDates, string startDates)
        {
            Quantity = Quantitys;
            Deposit = Deposits;
            Rent = Rents;
            TypeSelected = TypeSelecteds;
            TypeMountain = TypeMountains;
            TypeRacing = TypeRacings;
            TypeEBike = TypeEbikes;
            TypeCity = TypeCitys;
            totalDeposit = totalDeposits;
            totalQuantitty = totalQuantittys;
            totalRent = totalRents;
            startDate = startDates;
            endDate = endDates;
        }

        public CurrentOrder()
        {

        }

        public int Quantity { get; set; }
        public int Deposit { get; set; }
        public int Rent { get; set; }
        public string TypeSelected { get; set; }
        public string TypeMountain { get; set; }
        public string TypeRacing { get; set; }
        public string TypeCity { get; set; }
        public string TypeEBike { get; set; }
        public  int totalRent { get; set; }
        public int totalDeposit { get; set; }
        public int totalQuantitty { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

    }
}
