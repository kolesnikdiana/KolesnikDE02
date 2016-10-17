﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.18033
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFSoapServiceAirport.Model
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Flight", Namespace="http://schemas.datacontract.org/2004/07/WCFSoapServiceAirport.Model")]
    public partial class Flight : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string AirlineField;
        
        private int FlightIdField;
        
        private string FlightNumberField;
        
        private string FromField;
        
        private int PriceField;
        
        private string ToField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Airline
        {
            get
            {
                return this.AirlineField;
            }
            set
            {
                this.AirlineField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FlightId
        {
            get
            {
                return this.FlightIdField;
            }
            set
            {
                this.FlightIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FlightNumber
        {
            get
            {
                return this.FlightNumberField;
            }
            set
            {
                this.FlightNumberField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string From
        {
            get
            {
                return this.FromField;
            }
            set
            {
                this.FromField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Price
        {
            get
            {
                return this.PriceField;
            }
            set
            {
                this.PriceField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string To
        {
            get
            {
                return this.ToField;
            }
            set
            {
                this.ToField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IFlightService")]
public interface IFlightService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFlightService/GetAllFligths", ReplyAction="http://tempuri.org/IFlightService/GetAllFligthsResponse")]
    WCFSoapServiceAirport.Model.Flight[] GetAllFligths();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFlightService/AddFlight", ReplyAction="http://tempuri.org/IFlightService/AddFlightResponse")]
    void AddFlight(string n, string a, string f, string t, int p);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFlightService/DeleteFlight", ReplyAction="http://tempuri.org/IFlightService/DeleteFlightResponse")]
    void DeleteFlight(WCFSoapServiceAirport.Model.Flight f);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFlightService/FindFlights", ReplyAction="http://tempuri.org/IFlightService/FindFlightsResponse")]
    WCFSoapServiceAirport.Model.Flight[] FindFlights(string a);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFlightService/SortByPrice", ReplyAction="http://tempuri.org/IFlightService/SortByPriceResponse")]
    WCFSoapServiceAirport.Model.Flight[] SortByPrice();
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IFlightServiceChannel : IFlightService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class FlightServiceClient : System.ServiceModel.ClientBase<IFlightService>, IFlightService
{
    
    public FlightServiceClient()
    {
    }
    
    public FlightServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public FlightServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public FlightServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public FlightServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public WCFSoapServiceAirport.Model.Flight[] GetAllFligths()
    {
        return base.Channel.GetAllFligths();
    }
    
    public void AddFlight(string n, string a, string f, string t, int p)
    {
        base.Channel.AddFlight(n, a, f, t, p);
    }
    
    public void DeleteFlight(WCFSoapServiceAirport.Model.Flight f)
    {
        base.Channel.DeleteFlight(f);
    }
    
    public WCFSoapServiceAirport.Model.Flight[] FindFlights(string a)
    {
        return base.Channel.FindFlights(a);
    }
    
    public WCFSoapServiceAirport.Model.Flight[] SortByPrice()
    {
        return base.Channel.SortByPrice();
    }
}
