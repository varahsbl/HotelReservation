using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    class DateFormatter
    {
        public static DateTime ConvertToDate(string date)
        {

            DateTime dateTime = DateTime.Parse(date);
            return dateTime;

        }

        public static DateTime[] Dates(string startDate, String endDate)
        {

            DateTime startDateTime = ConvertToDate(startDate);
            DateTime endDateTime = ConvertToDate(endDate);

            TimeSpan time = endDateTime.Date - startDateTime.Date;
            int numberOfDays = time.Days + 1;
            DateTime[] dates = new DateTime[numberOfDays];

            for (int i = 0; i < numberOfDays; i++)
            {
                dates[i] = startDateTime.AddDays(i);
            }

            return dates;
        }
    }
}
