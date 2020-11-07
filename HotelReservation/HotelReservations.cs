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
       
        public List<Hotel> findCheapestHotelBasedOnDay(CustomerType customer, string initialDateRange, string endDateRange)
        {
             
        DateTime initialDateTime = DateFormatter.ConvertToDate(initialDateRange);
            DateTime endDateTime = DateFormatter.ConvertToDate(initialDateRange);
            
            List<Hotel> hotelList= new List<Hotel>();
            
            foreach(Hotel singleHotel in hotels) {
                int weekDay = 0;
                int weekEnd = 0;
                foreach (DateTime date in DateFormatter.Dates(initialDateRange, endDateRange))
                {
                    
                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        weekEnd += singleHotel.GetRate()[customer].GetWeekEndRate();

                    }
                    else
                    {
                        weekDay += singleHotel.GetRate()[customer].GetWeekDayRate();
                    }

                }
                singleHotel.SetTotalRate(weekDay + weekEnd);
                hotelList.Add(singleHotel);
            }
             hotels.OrderBy(x => x.GetTotalRate());
           
            return hotels.OrderBy(x => x.GetTotalRate()).ToList();


          
           

        }
    }
}
