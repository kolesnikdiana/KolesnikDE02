using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WCFSoapServiceAirport.Model;
using System.ServiceModel.Web;

namespace WCFSoapServiceAirport
{
    [ServiceContract]
    public interface IAirlineService
    {
        [OperationContract]
        List<Airline> GetAllAirlines();

        [OperationContract]
        void AddAirline(String a);

        [OperationContract]
        void DeleteAirline(Airline a);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/edit")]
        void EditAirline(Airline a, String newName);
    }
}
