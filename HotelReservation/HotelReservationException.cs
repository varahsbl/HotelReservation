using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public class HotelReservationException : Exception
    {
        public ExceptionType type;
        public string message;
        public enum ExceptionType
        {
            INVALID_DATERANGE, INVALID_DATEFORMAT
        }
        public HotelReservationException(String message, ExceptionType type)
           
        {
            this.message = message;
            this.type = type;
        }
       
    }
    
}
