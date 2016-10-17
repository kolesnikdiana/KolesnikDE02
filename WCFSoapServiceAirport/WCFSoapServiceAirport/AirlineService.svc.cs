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

        public void AddAirline(String airlineName)
        {
            Airline a = new Airline();
            a.AirlineName = airlineName;

            Airline[] listAirl = GetAllAirlines().ToArray();
            a.AirlineId = listAirl[listAirl.Length - 1].AirlineId + 1;
            string aJSON = JsonConvert.SerializeObject(a);

            File.AppendAllText(path, aJSON);
        }

        public void DeleteAirline(Airline a)
        {
            string airline = JsonConvert.SerializeObject(a);

            StreamReader sr = new StreamReader(path);
            String FlightDataJSON = sr.ReadToEnd();
            sr.Close();

            int index = FlightDataJSON.IndexOf(airline);
            String newJSON = FlightDataJSON.Remove(index, airline.Length);
            File.WriteAllText(path, newJSON);
        }

        public void EditAirline(Airline a, String newName)
        {
            StreamReader sr = new StreamReader(path);
            String AirlinesDataJSON = sr.ReadToEnd();
            sr.Close();

            string newJSON = AirlinesDataJSON.Replace(a.AirlineName, newName);

            File.WriteAllText(path, newJSON);
        }
    }
}
