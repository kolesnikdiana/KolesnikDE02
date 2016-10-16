using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WCFSoapServiceAirport.Model;

namespace WCFSoapServiceAirport
{
    [ServiceContract]
    public interface IAirlineService
    {
        [OperationContract]
        List<Airline> GetAllAirlines();

        [OperationContract]
        void AddAirline(Airline f);

        [OperationContract]
        void DeleteAirline(Airline f);
    }
}
