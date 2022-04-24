using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchProject.BusinessClasses
{
    public class Hotel : HolidayFactory
    {
       
        public string Name { get; set; }
        public string Arrival_Date { get; set; }
        public decimal Price_Per_Night { get; set; }
        public string[]Local_Airports { get; set; }
        public int Nights { get; set; }

        public static IQueryable<Hotel> Filter(IQueryable<Hotel> data, SearchQuery query)
        {

            if (query.TravelingTo != null && query.TravelingTo.Length > 0)
                data = data.Where((e) => FilterUtility.Compare(query.TravelingTo, e.Local_Airports));

            if (query.DepartureDate != null && query.DepartureDate.Length > 0)
                data = data.Where((e) => FilterUtility.Compare(query.DepartureDate, e.Arrival_Date));

            if (query.Duration != null && query.Duration.Length > 0)
                data = data.Where((e) => FilterUtility.Compare(query.Duration, e.Nights));

            return data;
        }

    }
}
