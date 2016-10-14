using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFSoapServiceAirport.Model
{
    public class Flight
    {
        public int Id { get; set; }

        public string FlightNumber { get; set; }

        public string Airline { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public int Price { get; set; }

    }
}