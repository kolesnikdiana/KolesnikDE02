using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using Newtonsoft.Json;
using System.Text;
using WCFSoapServiceAirport.Model;

namespace WCFSoapServiceAirport
{
    public class FlightService : IFlightService
    {
        /*FlightDbContext db = new FlightDbContext();*/

        private List<Flight> FlightData = new List<Flight> {
            new Flight { FlightNumber = "SU1833", Airline = "Aeroflot", From = "MSQ", To = "FRA", Price = 315 },
            new Flight { FlightNumber = "RE1441", Airline = "Luftgansa", From = "MSQ", To = "MSK", Price = 110 },
            new Flight { FlightNumber = "AW1011", Airline = "Aeroflot", From = "MSK", To = "FRA", Price = 225 }
        };

        public string GetAllFligth()
        {
            IEnumerable<Flight> flights = FlightData;

            return JsonConvert.SerializeObject(flights);
        }

        /*public Model.Flight Get(string flightNumber)
        {
            return db.Flights.Find(flightNumber);
        }

        public void Add(Flight f)
        {
            db.Flights.Add(f);
            db.SaveChanges();
        }

        public void Edit(Flight f)
        {
            db.Entry(f).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(string flightNumber)
        {
            Flight fl = db.Flights.Find(flightNumber);
            if (fl != null)
            {
                db.Flights.Remove(fl);
                db.SaveChanges();
            }
        }*/
    }
}
