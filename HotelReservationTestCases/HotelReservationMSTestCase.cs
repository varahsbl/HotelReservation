using HotelReservation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelReservationTestCases
{
    [TestClass]
    public class HotelReservationMSTestCase
    {
        private HotelReservations hotelService;

        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional
            this.hotelService = new HotelReservations();
        }

        // Started with Hotel Reservation.
        [TestMethod]
        public void whenCalledDisplayMethod_shouldDisplayWelcomeMessage()
        {
            this.hotelService.greetCustomer();
        }
    }
}
