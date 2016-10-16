using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFSoapServiceAirport.Model;

namespace WCFSoapServiceAirport
{
    [ServiceContract]
    public interface IFlightService
    {
        [OperationContract]
        List<Flight> GetAllFligths();

        [OperationContract]
        void AddFlight(Flight f);

        [OperationContract]
        void DeleteFlight(Flight f);

        [OperationContract]
        List<Flight> FindFlights(String airline);

        [OperationContract]
        Flight[] SortByPrice();
    }
}
