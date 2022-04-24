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
        private static Lazy<List<Hotel>> _data = new Lazy<List<Hotel>>(() => GetData());


        private static List<Hotel> GetData()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\Parikshit\source\repos\HolidaySearchProject\HolidaySearchProject\Assets\hotels.json"))
            {
                string json = r.ReadToEnd();
                List<Hotel> items = JsonConvert.DeserializeObject<List<Hotel>>(json);
                return items;
            }
        }

        public static List<Hotel> Data => _data.Value;
    }
}
