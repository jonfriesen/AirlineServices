using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirlineServices.Data;
using AirlineServices.Models;

namespace AirlineServices.Controllers
{
    public class FlightsController : Controller
    {
        private AirlineContext db = new AirlineContext();

        // GET: Flights
        public ActionResult Index(string source = null, string destination = null)
        {
            List<Flight> flights = db.flights.ToList();

            // If source is not null, reduce list to just those that match the source airport code
            if (source != null && source != "Source City")
            {
                flights = flights.Where(s => s.source.city == source).ToList();
            }

            // If destination is not null, reduce list to just those that match the destination airport code
            if (destination != null && destination != "Destination City")
            {
                flights = flights.Where(s => s.destination.city == destination).ToList();
            }

            var Locations = db.locations.Select(s => s.city).Distinct().ToList();
            ViewBag.Sources = db.locations.Select(s => s.city).Distinct().ToList();
            ViewBag.Sources.Insert(0, "Source City");
            ViewBag.Destinations = db.locations.Select(s => s.city).Distinct().ToList(); ;
            ViewBag.Destinations.Insert(0, "Destination City");


            return View(flights.OrderByDescending(s => s.departureDate));
        }

        // GET: Flights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // GET: Flights/Create
        public ActionResult Create()
        {
            //ViewBag.DestinationId = new SelectList(db.locations, "id", "city");
            //ViewBag.SourceId = new SelectList(db.locations, "id", "city");
            ViewBag.PlaneId = new SelectList(db.planes, "tailNumber", "tailNumber");

            ViewBag.DestinationId = db.locations.Select(s => new SelectListItem
                {
                    Value = s.id.ToString(),
                    Text = s.airportCode + " - " + s.city
                });
            ViewBag.SourceId = db.locations.Select(s => new SelectListItem
                {
                    Value = s.id.ToString(),
                    Text = s.airportCode + " - " + s.city
                });
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,departureDate,ticketPrice,status")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.flights.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }            
            ViewBag.DestinationId = db.locations.Select(s => new SelectListItem
                {
                    Value = s.id.ToString(),
                    Text = s.airportCode + " - " + s.city
                });
            ViewBag.SourceId = db.locations.Select(s => new SelectListItem
                {
                    Value = s.id.ToString(),
                    Text = s.airportCode + " - " + s.city
                });
            ViewBag.PlaneId = new SelectList(db.planes, "tailNumber", "tailNumber", flight.PlaneId);
            return View(flight);
        }

        // GET: Flights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,departureDate,ticketPrice,status")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flight);
        }

        // GET: Flights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flight flight = db.flights.Find(id);
            db.flights.Remove(flight);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
