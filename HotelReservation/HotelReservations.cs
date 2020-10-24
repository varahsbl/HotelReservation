using System;
using System.Collections.Generic;
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

    }
}
