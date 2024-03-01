using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Models
{
    public class Flight
    {
        public int FlightNumber { get; }
        public string DepartureCity { get; }
        public string ArrivalCity { get; }
        public int Day { get; }

        public Flight(int flightNumber, string departureCity, string arrivalCity, int day)
        {
            FlightNumber = flightNumber;
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            Day = day;
        }

        public override string ToString()
        {
            return $"Flight: {FlightNumber}, departure: {DepartureCity}, arrival: {ArrivalCity}, day: {Day}";
        }
    }
}
