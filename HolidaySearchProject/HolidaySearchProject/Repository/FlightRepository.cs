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
        private static Lazy<List<Flight>> _data = new Lazy<List<Flight>>(() => GetData());

 
        private static List<Flight> GetData()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\Parikshit\source\repos\HolidaySearchProject\HolidaySearchProject\Assets\flights.json"))
            {
                string json = r.ReadToEnd();
                List<Flight> items = JsonConvert.DeserializeObject<List<Flight>>(json);
                return items;
            }
        }

        public static List<Flight> Data => _data.Value;

    }
}


