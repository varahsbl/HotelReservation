using HotelReservation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservationTestCases
{
    [TestClass]
    public class HotelReservationMSTestCase
    {
        private HotelReservations hotelService;
        private Hotel lakewood;
        private Hotel bridgewood;
        private Hotel ridgewood;
       private Dictionary<CustomerType, Rate> customerTypeRate = new Dictionary<CustomerType, Rate>();

        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional
            this.hotelService = new HotelReservations();

           
            customerTypeRate.Add(CustomerType.REGULAR, new Rate(110, 90));
            customerTypeRate.Add(CustomerType.REWARD, new Rate(80, 80));
            lakewood = new Hotel("Lakewood", 3, customerTypeRate);

            customerTypeRate = new Dictionary<CustomerType, Rate>();
            customerTypeRate.Add(CustomerType.REGULAR, new Rate(160, 40));
            customerTypeRate.Add(CustomerType.REWARD, new Rate(110, 50));
            bridgewood = new Hotel("Bridgewood", 4, customerTypeRate);

            customerTypeRate = new Dictionary<CustomerType, Rate>();
            customerTypeRate.Add(CustomerType.REGULAR, new Rate(220, 150));
            customerTypeRate.Add(CustomerType.REWARD, new Rate(100, 40));
            ridgewood = new Hotel("Ridgewood", 5, customerTypeRate);
        }

        /// <summary>
        /// Started with Hotel Reservation.
        /// </summary>
        [TestMethod]
        public void WhenCalledDisplayMethod_shouldDisplayWelcomeMessage()
        {
            this.hotelService.greetCustomer();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GivenHotel_whenInvokedAddHotel_shouldBeAbleToAdd()
        {
            bool result = this.hotelService.addHotel(lakewood);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenDateRange_whenSearched_shouldBeAbleToAddRatingsForHotel()
        {
             this.hotelService.addHotel(lakewood);
             this.hotelService.addHotel(bridgewood);
            Hotel cheapestHotelResult = this.hotelService.findCheapestHotelBasedOnDay(CustomerType.REGULAR,
                "11Sep2020","12Sep2020");
            Assert.AreEqual(cheapestHotelResult.name,lakewood.name);
            Assert.AreEqual(cheapestHotelResult.GetTotalRate(), lakewood.GetRate()[CustomerType.REGULAR].GetWeekDayRate() *2 );
        }
        [TestMethod]
        public void GivenHotel_shouldBeAbleToAddRateAccordinfToDay()
        {
            customerTypeRate = new Dictionary<CustomerType, Rate>();
            customerTypeRate.Add(CustomerType.REGULAR, new Rate(160, 40));
            customerTypeRate.Add(CustomerType.REWARD, new Rate(110, 50));
            bridgewood = new Hotel("Bridgewood", 4, customerTypeRate);

            customerTypeRate = new Dictionary<CustomerType, Rate>();
            customerTypeRate.Add(CustomerType.REGULAR, new Rate(220, 150));
            customerTypeRate.Add(CustomerType.REWARD, new Rate(100, 40));
            ridgewood = new Hotel("Ridgewood", 5, customerTypeRate);

            bool result = this.hotelService.addHotel(lakewood);
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void GivenRating_whenInvokedAddHotel_shouldBeAbleToAdd()
        {
             Hotel lakewood = new Hotel("Lakewood", 3, null);
             bool result = this.hotelService.addHotel(lakewood);
             Assert.IsTrue(result);
        }
    }
}
