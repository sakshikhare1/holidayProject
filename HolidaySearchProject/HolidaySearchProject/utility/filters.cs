using System;
using System.Collections.Generic;
using System.Linq;


namespace HolidaySearchProject.BusinessClasses
{
   public static class FilterUtility
    {
        public static bool Compare(string[] param1, string param2)
        {

            return param1.Contains(param2);


        }
        public static bool Compare(int[] param1, int param2)
        {

            return param1.Contains(param2);


        }
        public static bool Compare(string[] param1, string[] param2)
        {

            return param1.Intersect(param2).Count() > 0;


        }
    }
}
