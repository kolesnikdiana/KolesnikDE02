using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using Newtonsoft.Json;
using System.Text;
using WCFSoapServiceAirport.Model;
using System.IO;
using System.Text.RegularExpressions;
using System.ServiceModel.Activation;
using System.Collections;

namespace WCFSoapServiceAirport
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FlightService : IFlightService
    {
        private String path = "E:/BSU/SOAP/WCFSoapServiceAirport/WCFSoapServiceAirport/api/flights.json";

        private String pathAir = "E:/BSU/SOAP/WCFSoapServiceAirport/WCFSoapServiceAirport/api/airlines.json";

        public List<Flight> GetAllFligths()
        {
            StreamReader sr = new StreamReader(path);
            String FlightDataJSON = sr.ReadToEnd();
            sr.Close();

            List<Flight> FlightData = new List<Flight>();
            string pattern = @"\{(.*?)\}";
            Regex rgx = new Regex(pattern);

            foreach (Match match in rgx.Matches(FlightDataJSON))
            {
                FlightData.Add(JsonConvert.DeserializeObject<Flight>(match.Value));
            }
            return FlightData;
        }
    
        public void AddFlight(Flight f)
        {
            Flight flight = new Flight();
            flight.FlightNumber = f.FlightNumber;
            flight.From = f.From;
            flight.To = f.To;
            flight.Price = f.Price;

            List<Airline> AirlineData = GetAllAirlines();

            if (AirlineData.Exists(x => x.AirlineName == f.Airline))
            {
                Airline a = AirlineData.Find(x => x.AirlineName == f.Airline);
            }
            else
            {
                Airline a = new Airline();
                a.AirlineName = f.Airline;

                Airline[] listAirl = AirlineData.ToArray();
                a.AirlineId = listAirl[listAirl.Length - 1].AirlineId + 1;
                string aJSON = JsonConvert.SerializeObject(a);

                File.AppendAllText(pathAir, aJSON);
            }

            flight.Airline = f.Airline;

            Flight[] listFls = GetAllFligths().ToArray();
            if (listFls.Length == 0)
            {
                flight.FlightId = 0;
            }
            else flight.FlightId = listFls[listFls.Length-1].FlightId + 1;

            string newFl = JsonConvert.SerializeObject(flight);
            File.AppendAllText(path, newFl);
        }

        public void DeleteFlight(Flight f)
        {
            string flight = JsonConvert.SerializeObject(f);

            StreamReader sr = new StreamReader(path);
            String FlightDataJSON = sr.ReadToEnd();
            sr.Close();

            int index = FlightDataJSON.IndexOf(flight);
            String newJSON = FlightDataJSON.Remove(index, flight.Length);
            File.WriteAllText(path, newJSON);
        }

        public List<Flight> FindFlights(String airline) 
        {
            List<Flight> flights = GetAllFligths();
            List<Flight> res = new List<Flight>();
            if (flights.ToArray().Length != 0)
            {
                List<Airline> airlines = GetAllAirlines();
                if (airlines.Exists(x => x.AirlineName == airline))
                {
                    foreach (Flight f in flights)
                    {
                        if (f.Airline == airline)
                        {
                            res.Add(f);
                        }

                    }
                }
            }

            return res;
        }

        private List<Airline> GetAllAirlines()
        {
            StreamReader sr = new StreamReader(pathAir);
            String AirlinesDataJSON = sr.ReadToEnd();
            sr.Close();

            List<Airline> AirlineData = new List<Airline>();
            string pattern = @"\{(.*?)\}";
            Regex rgx = new Regex(pattern);

            foreach (Match match in rgx.Matches(AirlinesDataJSON))
            {
                AirlineData.Add(JsonConvert.DeserializeObject<Airline>(match.Value));
            }

            return AirlineData;
        }

        public Flight[] SortByPrice()
        {
            Flight[] arr = GetAllFligths().ToArray();
            Array.Sort(arr, prComparer);
            
            return arr;
        }

        public int prComparer(Flight x, Flight y)
        {
            return (new CaseInsensitiveComparer()).Compare(x.Price, y.Price);
        }
    }
}
