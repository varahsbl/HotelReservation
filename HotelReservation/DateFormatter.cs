using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HotelReservation
{
    class DateFormatter
    {
        public static DateTime ConvertToDate(string date)
        {
            var dateFormats = "ddMMMyyyy" ;
            DateTime dateTime;
            if (DateTime.TryParseExact(date, dateFormats, new CultureInfo("en-US"), DateTimeStyles.None, out dateTime))
            {
                dateTime = DateTime.Parse(date);
            }else
            {
                throw (new HotelReservationException("Invalid Date Format", HotelReservationException.ExceptionType.INVALID_DATEFORMAT));

            }

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
