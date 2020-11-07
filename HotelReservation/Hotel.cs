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
        private int totalrate;

        public Hotel(String name, int rating, Dictionary<CustomerType, Rate> rate)
        {
            this.name = name;
            this.rating = rating;
            this.rate = rate;
        }
        public void SetTotalRate(int totalRate)
        {
            this.totalrate = totalRate;
        }
        public int GetTotalRate()
        {
            return this.totalrate;
        }
        public void setRate(Dictionary<CustomerType, Rate> rate)
        {
             this.rate=rate;
        }
        public Dictionary<CustomerType, Rate> GetRate()
        {
            return this.rate;
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
        public int GetWeekDayRate()
        {
            return this.weekdayRate;
        }

        public int GetWeekEndRate()
        {
            return this.weekendRate;
        }

        public int CompareTo(Rate value)
        {
           return this.weekdayRate.CompareTo(value.weekdayRate);
        }
    }
}


