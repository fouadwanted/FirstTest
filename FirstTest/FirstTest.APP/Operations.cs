using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstTest.APP.Models;

namespace FirstTest.APP
{
    public class Operations
    {
        private static int GetPassengerPrice(Passenger passenger)
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
        //Vérifier si la famille contient plus que 5 personne
        public bool CheckFamilyMembers(List<Passenger> Members)
        {
            bool statut = false;
            if (Members.Count > 5)
            {
                Console.WriteLine("le nombre max de passager est atteint");
                statut = true;
            }
            else if (Members.Count(a => a.Age < 12) > 3)
            {
                Console.WriteLine("le nombre max de passager enfant est atteint");
                statut = true;
            }
            else if (Members.Count(a => a.Age > 12) > 2)
            {
                Console.WriteLine("le nombre max de passager adulte est atteint");
                statut = true;
            }
            return statut;
        }
        //génération des passager selon leur famille
        public List<Family> GeneratePassengersAndFamilies()
        {
            List<Passenger> Passengers = new List<Passenger>();
            Family SingleMembres = new Family();
            List<Family> families = new List<Family>();
            Passengers.Add(new Passenger(1, "Ahmed", "A", 20, true));
            Passengers.Add(new Passenger(2, "lili", "B", 60, false));
            Passengers.Add(new Passenger(3, "Alex", "B", 10, false));
            Passengers.Add(new Passenger(3, "karim", "B", 60, false));
            Passengers.Add(new Passenger(3, "mohamed", "B", 15, false));
            Passengers.Add(new Passenger(3, "ali", "B", 10, false));
            Passengers.Add(new Passenger(4, "Said", "-", 20, true));
            Passengers.Add(new Passenger(4, "hanane", "-", 41, true));
            Passengers.Add(new Passenger(5, "nabila", "C", 50, false));
            // on groupe les passagers selon leurs nom de famille 
            var passengersByfamilies = Passengers.GroupBy(p => p.LastName).ToList();
            foreach (var groupe in passengersByfamilies)
            {
                Family family = new Family();
                foreach (var passenger in groupe.ToList())
                {
                    //les passagers seuls
                    if (groupe.Key == "-") SingleMembres.AddMember(passenger);
                    //On vérifier si la famille est a la limite de nombre max
                    if (CheckFamilyMembers(family.Members)) break;
                    else family.AddMember(passenger);
                }
                families.Add(family);
            }
            return families;
        }

        public void OptimizeFlightSeating(List<Family> families)
        {
            List<Passenger> passengers = new List<Passenger>();
            foreach (Family family in families)
            {
                passengers.AddRange(family.Members);
            }

            passengers = passengers.OrderByDescending(p => p.ExtraSeat).ToList();

            int totalRevenue = 0;

            for (int i = 0; i < passengers.Count; i++)
            {
                //On vérifie si on est a la limite de nombre de places possible
                if (i < 200)
                {
                    Console.WriteLine("Passager: " + passengers[i].Name + ", Prix: " + GetPassengerPrice(passengers[i]));
                    totalRevenue += GetPassengerPrice(passengers[i]);
                }
                else
                {
                    Console.WriteLine("pas de place pour : " + passengers[i].Name);
                }
            }

            Console.WriteLine("Total Revenue: " + totalRevenue);
        }
    }
}
