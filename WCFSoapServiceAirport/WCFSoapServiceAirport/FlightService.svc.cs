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
            Flight[] listFls = GetAllFligths().ToArray();
            f.FlightId = listFls[listFls.Length-1].FlightId + 1;
            string newFl = JsonConvert.SerializeObject(f);
            
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

        public List<Flight> FindFlights( String airline ) 
        {
            List<Flight> flights = GetAllFligths();
            List<Flight> res = new List<Flight>();
            foreach(Flight f in flights){
                if (f.Airline == airline)
                {
                    res.Add(f);
                }
                
            }

            return res;
        }

        public Flight[] SortByPrice()
        {
            Flight[] arr = GetAllFligths().ToArray();
            //IComparer prComparer = new PriceCompare()

            Array.Sort(arr, prComparer);
            
            return arr;
        }

        public int prComparer(Flight x, Flight y)
        {
            return (new CaseInsensitiveComparer()).Compare(x.Price, y.Price);
        }

    }
}
