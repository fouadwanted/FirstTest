using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTest.APP.Models
{
    public class Family
    {
        public List<Passenger> Members { get; }
        public int TotalPrice { get; private set; }

        public Family()
        {
            Members = new List<Passenger>();
        }

        public void AddMember(Passenger passenger)
        {
            Members.Add(passenger);
            TotalPrice += GetPassengerPrice(passenger);
        }

        private int GetPassengerPrice(Passenger passenger)
        {
            if (passenger.ExtraSeat)
            {
                return 500;
            }
            else if (passenger.Age < 12)
            {
                return 150;
            }
            else
            {
                return 250;
            }
        }
    }
}
