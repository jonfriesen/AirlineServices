using AirlineServices.Data;
using AirlineServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirlineServices.Controllers
{
    public class HomeController : Controller
    {

        private AirlineContext db = new AirlineContext();

        public ActionResult Index()
        {
            DashboardViewModel dashboard = new DashboardViewModel();

            dashboard.departingFlights = db.flights.OrderByDescending(s => s.departureDate).Take(5).ToList();
            dashboard.newestPassengers = db.passengers.OrderByDescending(s => s.CreateDate).Take(5).ToList();
            dashboard.recentlyUpdatedPassengers = db.passengers.OrderByDescending(s => s.LastModified).Take(5).ToList();

            return View(dashboard);
        }
    }
}