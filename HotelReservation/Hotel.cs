using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public class Hotel
    {
        private int rating;
        public string name;
        private Dictionary<CustomerType, Rate> rate;

        public Hotel(String name, int rating, Dictionary<CustomerType, Rate> rate)
        {
            this.name = name;
            this.rating = rating;
            this.rate = rate;
        }
    }

    public enum CustomerType
    {
        REGULAR, REWARD
    }

    public class Rate
    {
        private readonly int weekendRate;
        private readonly int weekdayRate;

        public Rate(int weekdayRate, int weekendRate)
        {
            this.weekdayRate = weekdayRate;
            this.weekendRate = weekendRate;
        }
    }
}


