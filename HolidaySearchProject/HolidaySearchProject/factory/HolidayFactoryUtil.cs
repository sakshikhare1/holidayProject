using HolidaySearchProject.BusinessClasses;
using HolidaySearchProject.Repository;
using System.Linq;


namespace HolidaySearchProject.factory
{
   public static class HolidayfactoryUtil
    {

        public static IQueryable<HolidayFactory> GetHolidayFromFactory(string holidayObject, SearchQuery _query)
        {
            switch (holidayObject)
            {
                case "flight":
                    //Get the filtered flight and order them by price 
                    return _getflights(_query).OrderBy(e => e.Price);
                //Get the filtered hotels and order them by price
                case "hotel":
                    return _getHotels(_query).OrderBy((e) => e.Price_Per_Night);

                default:
                    return null;
            }
        }

        //This method will get the filter data for flights 
        private static IQueryable<Flight> _getflights(SearchQuery _query)
        {
            return Flight.Filter(FlightRepository.Data, _query);

        }

        //This method will get the filter data for hotels
        private static IQueryable<Hotel> _getHotels(SearchQuery _query)
        {
            return Hotel.Filter(HotelRepository.Data, _query);
        }

    }
}
