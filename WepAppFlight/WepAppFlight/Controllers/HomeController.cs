using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WepAppFlight.FlightServiceReference;

namespace WepAppFlight.Controllers
{
    public class HomeController : Controller
    {
        public FlightServiceClient client = new FlightServiceClient();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var f = new Flight();
            return View(f);
        }

        [HttpPost]
        public ActionResult Create(Flight f)
        {
            if(f.Price > 0)
            {
                client.AddFlight(f);
                return Redirect("/Home/Flights");
            }
            return Redirect("/Home/Create");
        }

        public ActionResult Delete(int id = 0)
        {
            var flights = client.GetAllFligths();
            foreach(var f in flights)
            {
                if(f.FlightId == id)
                {
                    client.DeleteFlight(f);
                    break;
                }
            }            
            return Redirect("/Home/Flights");
        }

        [HttpPost]
        public ActionResult Delete(Flight f)
        {
            client.DeleteFlight(f);
            return Redirect("/Home/Flights");
        }

        public ActionResult SortByPrice()
        {
            var flights = client.SortByPrice();
            return new JsonResult {Data = flights, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        public ActionResult Flights()
        {   
            var flights = client.GetAllFligths();
            if(flights.Length > 0)
            {
                ViewBag.Message = "Available flights:";
            } else
            {
                ViewBag.Message = "No available flights";
            }
            ViewBag.Flights = flights;


            return View();
        }


    }
}