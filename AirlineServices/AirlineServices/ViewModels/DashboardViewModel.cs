using AirlineServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineServices.ViewModels
{
    public class DashboardViewModel
    {
        public List<Flight> departingFlights { get; set; }
        public List<Passenger> newestPassengers { get; set; }
        public List<Passenger> recentlyUpdatedPassengers { get; set; }
    }
}