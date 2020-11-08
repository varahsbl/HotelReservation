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
        public void GivenDateRange_whenSearched_shouldBeAbleToFindCheapestHotelBasedOnWeekDay()
        {
             this.hotelService.addHotel(lakewood);
             this.hotelService.addHotel(bridgewood);
           List< Hotel> cheapestHotelResult = this.hotelService.findCheapestHotelBasedOnDay(CustomerType.REGULAR,
                "11Sep2020","12Sep2020");
            Assert.AreEqual(cheapestHotelResult[0].name,lakewood.name);
            Assert.AreEqual(cheapestHotelResult[0].GetTotalRate(), lakewood.GetRate()[CustomerType.REGULAR].GetWeekDayRate() + lakewood.GetRate()[CustomerType.REGULAR].GetWeekEndRate());
        }
        [TestMethod]
        public void GivenHotel_shouldBeAbleToAddRateAccordingToDay()
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
        public void GivenDateRange_whenSearched_shouldBeAbleToFindCheapestHotelBasedOnWeekEnd()
        {
            this.hotelService.addHotel(lakewood);
            this.hotelService.addHotel(bridgewood);
            List<Hotel> cheapestHotelResult = this.hotelService.findCheapestHotelBasedOnDay(CustomerType.REGULAR,
                "11Sep2020", "12Sep2020");
            Assert.AreEqual(cheapestHotelResult[1].name, bridgewood.name);
            Assert.AreEqual(cheapestHotelResult[1].GetTotalRate(), bridgewood.GetRate()[CustomerType.REGULAR].GetWeekDayRate() + bridgewood.GetRate()[CustomerType.REGULAR].GetWeekEndRate());

            Assert.AreEqual(cheapestHotelResult[0].name, lakewood.name);
            Assert.AreEqual(cheapestHotelResult[0].GetTotalRate(), lakewood.GetRate()[CustomerType.REGULAR].GetWeekDayRate() + lakewood.GetRate()[CustomerType.REGULAR].GetWeekEndRate());
          
        }
        [TestMethod]
        public void GivenRating_whenInvokedAddHotel_shouldBeAbleToAddRatingsForHotel()
        {
             Hotel lakewood = new Hotel("Lakewood", 3, null);
             bool result = this.hotelService.addHotel(lakewood);
             Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenDates_whenInvokedFindCheapestBestRatedHotel_shouldBeAbleToFindCheapestBestRatedHotelBased()
        {
            this.hotelService.addHotel(lakewood);
            this.hotelService.addHotel(bridgewood);
            this.hotelService.addHotel(ridgewood);

            List<Hotel> cheapestBestHotels = this.hotelService.findCheapesBestRatedtHotel(CustomerType.REGULAR,
                "11Sep2020", "12Sep2020");
            Assert.AreEqual(cheapestBestHotels.Count, 1);
            Assert.AreEqual(cheapestBestHotels[0].name, bridgewood.name);
            Assert.AreEqual(cheapestBestHotels[0].GetRatings(), bridgewood.GetRatings());
        }
        [TestMethod]
        public void GivenDates_whenInvokedFindBestRatedHotel_shouldBeAbleToFindBestRatedHotelBased()
        {
            this.hotelService.addHotel(lakewood);
            this.hotelService.addHotel(bridgewood);
            this.hotelService.addHotel(ridgewood);
            List<Hotel> cheapestBestHotels = this.hotelService.findBestRatedtHotel(CustomerType.REGULAR,
                "11Sep2020", "12Sep2020");
            Assert.AreEqual(cheapestBestHotels[1].name, ridgewood.name);
            Assert.AreEqual(cheapestBestHotels[1].GetTotalRate(), 370);
        }
        [TestMethod]
        public void GivenHotel_whenInvokedAddHotelForRewardCustomers_shouldBeAbleToAddSpecialRate()
        {
            this.hotelService.addHotel(lakewood);
            this.hotelService.addHotel(bridgewood);
            this.hotelService.addHotel(ridgewood);
            bool lakewoodresult = this.hotelService.addHotel(lakewood);
            bool bridgewoodresult = this.hotelService.addHotel(bridgewood);
            bool ridgewoodresult = this.hotelService.addHotel(ridgewood);

            Assert.IsTrue(lakewoodresult);
            Assert.IsTrue(bridgewoodresult);
            Assert.IsTrue(ridgewoodresult);
        }
        [TestMethod]
        public void GivenDateRange_whenInvokedFindCheapestBestRatedHotel_shouldBeAbleToFindCheapestBestRatedHotelBasedOnRewardCustomerType()
        {
            this.hotelService.addHotel(lakewood);
            this.hotelService.addHotel(bridgewood);
            this.hotelService.addHotel(ridgewood);
            List<Hotel> cheapestBestHotels = this.hotelService.findBestRatedtHotel(CustomerType.REWARD,
                "11Sep2020", "12Sep2020");
            Assert.AreEqual(cheapestBestHotels[1].name, ridgewood.name);
            Assert.AreEqual(cheapestBestHotels[1].GetTotalRate(), 140);
            Assert.AreEqual(cheapestBestHotels[1].GetRatings(), ridgewood.GetRatings());

        }


    }
}
