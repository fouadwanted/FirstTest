using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTest.APP.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool ExtraSeat { get; set; }

        public Passenger(int id, string name, string lastName, int age, bool extraSeat)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Age = age;
            ExtraSeat = extraSeat;
        }
    }
}
