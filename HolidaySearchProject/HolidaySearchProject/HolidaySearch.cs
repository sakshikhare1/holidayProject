using HolidaySearchProject.BusinessClasses;
using HolidaySearchProject.factory;
using HolidaySearchProject.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;


namespace HolidaySearchTestProject
{
    public class HolidaySearch
    {
        public List<Holiday> Results { get; set; }
        private SearchQuery _query {  get;  }
    
        public HolidaySearch(
         string jsonQueryString
        )
        {
            try
            {
                //Parsing json query data into Search Query object, in case json object has some bad data,request wont go through
                _query = JsonConvert.DeserializeObject<SearchQuery>(jsonQueryString.ToUpper());
               
            }
            catch (Exception e)
            {
                throw new Exception("Bad request, check the query data",e);
            }

            if (_query != null)
            {
                //Get the fligts by query
                var flights = HolidayfactoryUtil.GetHolidayFromFactory("flight", _query) as IQueryable<Flight>;
                //Get the hotels by query
                var hotels = HolidayfactoryUtil.GetHolidayFromFactory("hotel", _query) as IQueryable<Hotel>;

                //Create hoildays from available flight & hotels
                Results = Holiday.CreateHolidays(flights, hotels);
            }
        }
      
    }

   
}


