
using System.Collections.Generic;
using System.Linq;


namespace HolidaySearchProject.BusinessClasses
{
   public class Holiday
    {
        public Flight Flight { get; set; }
        public Hotel  Hotel { get; set; }
        public decimal TotalPrice { get; set; }

        private Holiday(Flight flight, Hotel hotel)
        {
            Flight = flight;
            Hotel = hotel;
            //Total price is calculated here in contructor, we simply add Price of flight + (hotel per night * number of nights)
            TotalPrice = flight.Price + (hotel.Price_Per_Night * hotel.Nights);
        }

        public static List<Holiday> CreateHolidays(IQueryable<Flight> flights, IQueryable<Hotel> hotels)
        {
            List<Holiday> result = null;
            // Get the count of number of flight found after search 10
            var flightsCount = flights.Count();
            // Get the count of number of hotels found after search 2
            var hotelsCount = hotels.Count();

            //Scenario where number of flights are more than number of hotels or vice a versa
            var lengthOfShortestArray = flightsCount < hotelsCount ? flightsCount : hotelsCount;

            int i = 0;
            //Let go through the boths the fligh and hotel array and contruct holiday object
            while (lengthOfShortestArray > i)
            {
                if (result == null)
                    result = new List<Holiday>();

                var flight = flights.ElementAtOrDefault(i);

                var hotel = hotels.ElementAtOrDefault(i);

                result.Add(new Holiday(flight as Flight, hotel as Hotel));

                i++;
            }

            return result;
        }

        
    }
}
