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
        string GetAllFligth();

        /*[OperationContract]
        Flight Get(string flightNumber);

        [OperationContract]
        void Add(Flight f);

        [OperationContract]
        void Edit(Flight f);

        [OperationContract]
        void Delete(string flightNumber);*/
    }
}
