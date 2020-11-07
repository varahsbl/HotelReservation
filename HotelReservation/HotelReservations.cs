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
            var hotel=new Hotel();
            int numberOfDays = endDateTime.Day-initialDateTime.Day+1;
            foreach (Hotel hot in hotels)
            {
                var myList = hot.GetRate().ToList();
                myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
                hot.setRate(myList.ToDictionary(x => x.Key,y => y.Value));
                hotel=hotels.OrderBy(x=>x.GetRate()[customer].GetWeekDayRate()).First();
                Console.WriteLine("--->************", hot.name);
            }

            //    var hotel = hotels.OrderBy(kvp => kvp.GetRate()).First();
            Console.WriteLine("--->******hot rate******", hotel.GetRate()[customer].GetWeekDayRate());
            hotel.SetTotalRate(hotel.GetRate()[customer].GetWeekDayRate() * numberOfDays);
            return hotel;

        }
    }
}
