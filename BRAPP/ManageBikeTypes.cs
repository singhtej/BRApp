using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental_Application
{
    public class ManageBikeTypes
    {
        public ManageBikeTypes(int Quantitys, string Types,
          int Deposits, int Rents)
        {
            Quantity = Quantitys;
            Type = Types;
            Deposit = Deposits;
            Rent = Rents;

        }

        public ManageBikeTypes()
        { }

        public string Type { get; set; }
        public int Quantity { get; set; }
        public int Rent { get; set; }
        public int Deposit { get; set; }
    }
}
