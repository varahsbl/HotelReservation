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

            foreach (Hotel singleHotel in hotels)
            {
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
            }
            return hotels.OrderBy(x => x.GetTotalRate()).ToList();
        }
        public List<Hotel> findCheapesBestRatedtHotel(CustomerType customer, string initialDateRange, string endDateRange)
        {
            List<Hotel> cheapestHotels = findCheapestHotelBasedOnDay(customer, initialDateRange, endDateRange);
            cheapestHotels.Sort((e1, e2) => e1.GetRatings().CompareTo(e2.GetRatings()));
            int highestRating = cheapestHotels.Last().GetRatings();
            int cheapestRating = cheapestHotels.First().GetRatings();
            return cheapestHotels.FindAll(e => e.GetRatings() != highestRating && e.GetRatings() != cheapestRating);

        }

        public List<Hotel> findBestRatedtHotel(CustomerType customer, string initialDateRange, string endDateRange)
        {
            List<Hotel> cheapestHotels = findCheapestHotelBasedOnDay(customer, initialDateRange, endDateRange);
            cheapestHotels.Sort((e1, e2) => e1.GetRatings().CompareTo(e2.GetRatings()));
            int highestRating = cheapestHotels.Last().GetRatings();
            int cheapestRating = cheapestHotels.First().GetRatings();
            return cheapestHotels.FindAll(e => e.GetRatings() != cheapestRating);
        }
    }
}
