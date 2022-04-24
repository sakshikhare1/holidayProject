using System.Collections.Generic;
using System.Linq;


namespace HolidaySearchProject.BusinessClasses
{
   public class Flight: HolidayFactory
    {
      
        public string Airline { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Price { get; set; }
        public string Departure_Date { get; set; }

        public static IQueryable<Flight> Filter(IQueryable<Flight> data, SearchQuery query)
        {
           
            if (query.DepartingFrom != null && query.DepartingFrom.Length > 0)
                data = data.Where((e) => FilterUtility.Compare(query.DepartingFrom, e.From));

            if (query.TravelingTo != null && query.TravelingTo.Length > 0)
                data = data.Where((e) => FilterUtility.Compare(query.TravelingTo, e.To));

            if (query.DepartureDate != null && query.DepartureDate.Length > 0)
                data = data.Where((e) => FilterUtility.Compare(query.DepartureDate, e.Departure_Date));

            return data;
        }


    }
}
