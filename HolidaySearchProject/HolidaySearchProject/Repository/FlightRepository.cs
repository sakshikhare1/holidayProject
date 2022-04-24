using HolidaySearchProject.BusinessClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchProject.Repository
{
    static class FlightRepository
    {
        private static Lazy<IQueryable<Flight>> _data = new Lazy<IQueryable<Flight>>(() => GetData());

 
        private static IQueryable<Flight> GetData()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\Parikshit\source\repos\HolidaySearchProject\HolidaySearchProject\Assets\flights.json"))
            {
                string json = r.ReadToEnd();
                IEnumerable<Flight> items = JsonConvert.DeserializeObject<IEnumerable<Flight>>(json);
                return items.AsQueryable();
            }
        }

        public static IQueryable<Flight> Data => _data.Value;

    }
}


