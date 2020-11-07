using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelReservation
{
    public class HotelReservations
    {
        private List<Hotel> hotels;

        public HotelReservations()
        {
            this.hotels = new List<Hotel>();
        }

        public void greetCustomer()
        {
            Console.WriteLine("**************************************************************");
            Console.WriteLine("********* Welcome to Online Hotel Reservation Service ********");
            Console.WriteLine("**************************************************************");
        }

        public bool addHotel(Hotel hotel)
        {
            this.hotels.Add(hotel);
            if (this.hotels.Contains(hotel))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Hotel findCheapestHotelBasedOnDay(CustomerType customer, string initialDateRange, string endDateRange)
        {
            DateTime initialDateTime = DateTime.Parse(initialDateRange);
            DateTime endDateTime = DateTime.Parse(endDateRange);

            int numberOfDays = endDateTime.Day-initialDateTime.Day+1;
            foreach (Hotel hot in hotels)
            {
                var myList = hot.GetRate().ToList();
                myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
                hot.setRate(myList.ToDictionary(x => x.Key,y => y.Value));
                hotels.OrderBy(x=>x.GetRate()[CustomerType.REGULAR].GetWeekDayRate());
                Console.WriteLine("--->************", hot.name);
            }
                              
            var hotel = hotels.OrderBy(kvp => kvp.GetRate()).First();
            hotel.SetTotalRate(hotel.GetRate()[CustomerType.REGULAR].GetWeekDayRate() * numberOfDays);
            return hotel;

        }
    }
}
