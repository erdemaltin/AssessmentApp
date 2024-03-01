using System;
using System.Collections.Generic;
using System.IO;
using Assessment.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpeedyAirly
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exitRequested = false;

            while (!exitRequested)
            {
                Console.WriteLine("Which project would you like to run?");
                Console.WriteLine("1. First project");
                Console.WriteLine("2. Second project");
                Console.WriteLine("Type 3 to quit.");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        RunFirstProject();
                        break;
                    case "2":
                        RunSecondProject();
                        break;
                    case "3":
                        exitRequested = true;
                        break;
                    default:
                        Console.WriteLine("Invalid value. Please enter 1, 2, or 3.");
                        break;
                }
            }
        }
        static void RunFirstProject()
        {
            string ordersJsonData = File.ReadAllText("orders.json");
            var orders = JArray.Parse(ordersJsonData);
            var flights = new List<Flight>();
            string departureCity = "YUL";
            int flightNumber = 1;

            Dictionary<string, int> arrivalCount = new Dictionary<string, int>();
            Dictionary<string, int> arrivalDay = new Dictionary<string, int>();

            foreach (JObject order in orders)
            {
                string destination = (string)order["Destination"];
                string arrivalCity = destination;

                if (!arrivalCount.ContainsKey(destination))
                {
                    arrivalCount[destination] = 1;
                }
                else
                {
                    arrivalCount[destination]++;
                }

                if (!arrivalDay.ContainsKey(destination))
                {
                    arrivalDay[destination] = 1;
                }

                if (arrivalCount[destination] > 20)
                {
                    arrivalDay[destination]++;
                    arrivalCount[destination] = 1;
                }

                flights.Add(new Flight(flightNumber, departureCity, arrivalCity, arrivalDay[destination]));

                flightNumber++;
            }

            Console.WriteLine("Flight Schedule:");
            foreach (var flight in flights)
            {
                Console.WriteLine(flight);
            }

            Console.ReadLine();
        }

        static void RunSecondProject()
        {
            string ordersJsonData = File.ReadAllText("orders.json");
            var orders = JArray.Parse(ordersJsonData);
            var listedOrder = new List<Order>();
            string departureCity = "YUL";
            int flightNumber = 1;

            Dictionary<string, int> arrivalCount = new Dictionary<string, int>();
            Dictionary<string, int> arrivalDay = new Dictionary<string, int>();

            foreach (JObject order in orders)
            {
                string destination = (string)order["Destination"];
                string arrivalCity = destination;
                string orderName = (string)order["OrderName"];

                if (!arrivalCount.ContainsKey(destination))
                {
                    arrivalCount[destination] = 1;
                }
                else
                {
                    arrivalCount[destination]++;
                }

                if (!arrivalDay.ContainsKey(destination))
                {
                    arrivalDay[destination] = 1;
                }

                if (arrivalCount[destination] > 20)
                {
                    arrivalDay[destination]++;
                    arrivalCount[destination] = 1;
                }

                listedOrder.Add(new Order(orderName, "not scheduled", departureCity, arrivalCity, arrivalDay[destination]));

                if (arrivalCount[destination] >= 20)
                {
                    foreach (var list in listedOrder)
                    {
                        if (list.ArrivalCity == destination && list.FlightNumber == "not scheduled")
                        {
                            list.FlightNumber = flightNumber.ToString();
                        }
                    }

                    flightNumber++;
                }
            }

            Console.WriteLine("Flight Orders:");
            foreach (var list in listedOrder)
            {
                Console.WriteLine(list);
            }

            Console.ReadLine();
        }
    }
}
