using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Models
{
    public class Order
    {
        public string OrderName { get; }
        public string FlightNumber { get; set; }
        public string DepartureCity { get; }
        public string ArrivalCity { get; }
        public int Day { get; }

        public Order(string orderName, string flightNumber, string departureCity, string arrivalCity, int day)
        {
            OrderName = orderName;
            FlightNumber = flightNumber;
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            Day = day;
        }

        public override string ToString()
        {
            return $"Order: {OrderName}, flightNumber: {FlightNumber}, departure: {DepartureCity}, arrival: {ArrivalCity}, day: {Day}";
        }
    }
}
