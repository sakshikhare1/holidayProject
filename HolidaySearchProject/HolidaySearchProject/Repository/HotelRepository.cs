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
     class HotelRepository
    {
        private static Lazy<IQueryable<Hotel>> _data = new Lazy<IQueryable<Hotel>>(() => GetData());


        private static IQueryable<Hotel> GetData()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\Parikshit\source\repos\HolidaySearchProject\HolidaySearchProject\Assets\hotels.json"))
            {
                string json = r.ReadToEnd();
                IEnumerable<Hotel> items = JsonConvert.DeserializeObject<IEnumerable<Hotel>>(json);
                return items.AsQueryable();
            }
        }

        public static IQueryable<Hotel> Data => _data.Value;
    }
}
