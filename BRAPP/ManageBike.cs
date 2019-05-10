using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental_Application
{
    public class ManageBike
    {
        public ManageBike(int AvailableBikes, int TotalBikes,
           int RentedBikes)
        {
            AvailableBike = AvailableBikes;
            RentedBike = RentedBikes;
            TotalBike = TotalBikes;
        }

        public ManageBike()
        { }

        public int AvailableBike { get; set; }
        public int RentedBike { get; set; }
        public int TotalBike { get; set; }
    }
}
