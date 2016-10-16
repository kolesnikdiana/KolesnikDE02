using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Text;
using WCFTestClient.ServiceReference1;

namespace WCFTestClient
{
    class Program
    {
        private static FlightServiceClient client = new FlightServiceClient();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to the Flights Info Site!");
            Init();

            Console.ReadLine();
            client.Close();
        }

        private static void Init()
        {
            Console.WriteLine("\n-------------------------\nPlease, choose an action:\n1 -- Look available flights\n2 -- Add new flight\n3 -- Delete flight\n4 -- Find flights of Airline\n5 -- Sort by price\n0 -- Exit\n");
            int caseSwitch = ReadInt();

            switch (caseSwitch)
            {
                case 0:
                    client.Close();
                    Environment.Exit(0);
                    break;
                case 1:
                    var flights = client.GetAllFligths();

                    if (flights.Length > 0)
                    {

                        Console.WriteLine("\n-------------------------\nAvailable flights:");
                        foreach (WCFSoapServiceAirport.Model.Flight fl in flights)
                        {
                            Console.WriteLine("{0, -10} {1, -12} {2, -13} {3, -10} {4, -10}", "№ " + fl.FlightNumber, fl.Airline, " from: " + fl.From, "to: " + fl.To, " | $ " + fl.Price);
                        }
                    }
                    else Console.WriteLine("\n-------------------------\nThere're NO available flights");
                    Init();
                    break;
                case 2:
                    Console.WriteLine("\n-------------------------\n");
                    Console.WriteLine("Enter a flight number");
                    String flNumber = Console.ReadLine();
                    Console.WriteLine("Enter an airline name");
                    String airline = Console.ReadLine();
                    Console.WriteLine("Enter departure point");
                    String from = Console.ReadLine();
                    Console.WriteLine("Enter destination");
                    String to = Console.ReadLine();
                    Console.WriteLine("Enter ticket's price");
                    int price = ReadInt();

                    client.AddFlight(new WCFSoapServiceAirport.Model.Flight() { FlightNumber = flNumber, Airline = airline, From = from, To = to, Price = price });

                    Init();
                    break;
                case 3:
                    flights = client.GetAllFligths();

                    Console.WriteLine("\n-------------------------\nChoose flight to delete:");
                    var i = 1;
                    foreach (WCFSoapServiceAirport.Model.Flight fl in flights)
                    {
                        Console.WriteLine(i+". "+fl.FlightNumber);
                        i++;
                    }
                    i = ReadInt();
                    var f = flights[i - 1];
                    client.DeleteFlight(f);

                    Init();
                    break;
                case 4:
                    Console.WriteLine("\n-------------------------\nEnter an airline name:");
                    String line = Console.ReadLine();
                    flights = client.FindFlights(line);
                    if (flights.Length > 0)
                    {
                        foreach (WCFSoapServiceAirport.Model.Flight fl in flights)
                        {
                            Console.WriteLine("{0, -10} {1, -12} {2, -13} {3, -10} {4, -5}", "№ " + fl.FlightNumber, fl.Airline, " from: " + fl.From, "to: " + fl.To, " | $ " + fl.Price);
                        }
                    }
                    else Console.WriteLine("There're NO flights of the '" + line + "' airline");
                    Init();
                    break;
                case 5:
                    flights = client.SortByPrice();
                    Console.WriteLine("\n-------------------------\nSorted by price:");
                    foreach (WCFSoapServiceAirport.Model.Flight fl in flights)
                    {
                        Console.WriteLine("{0, -10} {1, -12} {2, -13} {3, -10} {4, -5}", "№ " + fl.FlightNumber, fl.Airline, " from: " + fl.From, "to: " + fl.To, " | $ " + fl.Price);
                    }
                    Init();
                    break;

                default:
                    Console.WriteLine("\n-------------------------\nThere're no such an option");
                    Init();
                    break;
            }
        }

        private static int ReadInt() 
        {
            string line = Console.ReadLine();
            int number;

            bool result = Int32.TryParse(line, out number);
            if (result)
            {
                return Int32.Parse(line);
            }
            else
            {
                Console.WriteLine("Please, enter a number");
                return ReadInt();
            }
        }
    }
}
