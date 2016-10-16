using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using WCFSoapServiceAirport.Model;
using System.ServiceModel.Activation;

namespace WCFSoapServiceAirport
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AirlineService : IAirlineService
    {

        private String path = "E:/BSU/SOAP/WCFSoapServiceAirport/WCFSoapServiceAirport/api/airlines.json";

        public List<Airline> GetAllAirlines()
        {
            StreamReader sr = new StreamReader(path);
            String FlightDataJSON = sr.ReadToEnd();
            sr.Close();

            List<Airline> AirlineData = new List<Airline>();
            string pattern = @"\{(.*?)\}";
            Regex rgx = new Regex(pattern);

            foreach (Match match in rgx.Matches(FlightDataJSON))
            {
                AirlineData.Add(JsonConvert.DeserializeObject<Airline>(match.Value));
            }
            return AirlineData;
        }

        public void AddAirline(Airline f)
        {
            Airline[] listAirl = GetAllAirlines().ToArray();
            f.AirlineId = listAirl[listAirl.Length - 1].AirlineId + 1;
            string newAirl = JsonConvert.SerializeObject(f);

            File.AppendAllText(path, newAirl);
        }

        public void DeleteAirline(Airline f)
        {
            string airline = JsonConvert.SerializeObject(f);

            StreamReader sr = new StreamReader(path);
            String FlightDataJSON = sr.ReadToEnd();
            sr.Close();

            int index = FlightDataJSON.IndexOf(airline);
            String newJSON = FlightDataJSON.Remove(index, airline.Length);
            File.WriteAllText(path, newJSON);
        }
    }
}
