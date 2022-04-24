using System;
using HolidaySearchProject.BusinessClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HolidaySearchTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCase1()
        {
            var JsonQuery = @"{
                               DepartingFrom: ['MAN'],
                               TravelingTo: ['AGP'],
                               DepartureDate: ['2023-07-01'],
                               Duration: [7]
                               }";
           var output = new HolidaySearch(JsonQuery);
           var flightid = output.Results[0].Flight.Id;
            var hotelid = output.Results[0].Hotel.Id;
            Assert.AreEqual(2, flightid);
            Assert.AreEqual(9, hotelid);


        }

        [TestMethod]
        public void TestCase2()
        {
           
           var JsonQuery = @"{
                               DepartingFrom: ['BQH','LCY','LGW','LHR','LTN','STN','NHT'],
                               TravelingTo: ['PMI'],
                               DepartureDate: ['2023-06-15'],
                               Duration: [10]
                               }";
            var output = new HolidaySearch(JsonQuery);
            var flightid = output.Results[0].Flight.Id;
            var hotelid = output.Results[0].Hotel.Id;
            Assert.AreEqual(6, flightid);
            Assert.AreEqual(5, hotelid);


        }

        [TestMethod]
        public void TestCase3()
        {

            var JsonQuery = @"{
                               TravelingTo: ['LPA'],
                               DepartureDate: ['2022-11-10'],
                               Duration: [14]
                               }";
            var output = new HolidaySearch(JsonQuery);
            var flightid = output.Results[0].Flight.Id;
            var hotelid = output.Results[0].Hotel.Id;
            Assert.AreEqual(7, flightid);
            Assert.AreEqual(6, hotelid);


        }
        [TestMethod]
        public void TestCase4()
        {

            var JsonQuery = @"{
                               TravelingTo: ['TFS'],
                               Duration: [7]
                               }";
            var output = new HolidaySearch(JsonQuery);
            var flightid = output.Results[0].Flight.Id;
            var hotelid = output.Results[0].Hotel.Id;
            Assert.AreEqual(1, flightid);
            Assert.AreEqual(2, hotelid);


        }
        [TestMethod]
        public void TestCase5()
        {

            var JsonQuery = @"{
                               DepartingFrom: ['LTN'],
                               TravelingTo: ['PMI'],
                               
                               }";
            var output = new HolidaySearch(JsonQuery);
            var flightid = output.Results[0].Flight.Id;
            var hotelid = output.Results[0].Hotel.Id;
            Assert.AreEqual(4, flightid);
            Assert.AreEqual(3, hotelid);


        }

        [TestMethod]
        public void TestCase6()
        {

            var JsonQuery = @"{
                               DepartureDate: ['2022-11-10'],
                               TravelingTo: ['LPA'],
                              }";
            var output = new HolidaySearch(JsonQuery);
            var flightid = output.Results[0].Flight.Id;
            var hotelid = output.Results[0].Hotel.Id;
            Assert.AreEqual(7, flightid);
            Assert.AreEqual(3, hotelid);


        }

    }
}
