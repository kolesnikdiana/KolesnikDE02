using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCFTestClient.ServiceReference1;

namespace WCFTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightServiceClient client = new FlightServiceClient();

            Console.WriteLine("available flights:");

            var flights = client.GetAllFligth();

            Console.WriteLine(flights);

            /*foreach( var fl in flights)
            {
                Console.WriteLine(fl.FlightNumber);
            }*/

            Console.ReadLine();
            client.Close();
        }
    }
}
