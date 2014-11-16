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
    public class TicketsController : Controller
    {
        private AirlineContext db = new AirlineContext();

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = db.tickets.Include(t => t.flight).Include(t => t.passenger);
            return View(tickets.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.FlightId = db.flights.Select(s => new SelectListItem
            {
                Value = s.id.ToString(),
                Text = s.source.city + " - " + s.destination.city + " on " + s.departureDate.ToString()
            });
            ViewBag.PassengerId = new SelectList(db.passengers, "id", "FullName");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FlightId,PassengerId,type")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.status = TicketStatusType.BOOKED;
                db.tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            foreach (var modelStateValue in ViewData.ModelState.Values)
            {
                foreach (var error in modelStateValue.Errors)
                {
                    // Do something useful with these properties
                    var errorMessage = error.ErrorMessage;
                    var exception = error.Exception;
                }
            }
            ViewBag.FlightId = db.flights.Select(s => new SelectListItem
            {
                Value = s.id.ToString(),
                Text = s.source.city + " - " + s.destination.city + " on " + s.departureDate.ToString()
            });
            ViewBag.PassengerId = new SelectList(db.passengers, "id", "givenName", ticket.PassengerId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.FlightId = db.flights.Select(s => new SelectListItem
            {
                Value = s.id.ToString(),
                Text = s.source.city + " - " + s.destination.city + " on " + s.departureDate.ToString()
            });
            ViewBag.PassengerId = new SelectList(db.passengers, "id", "FullName", ticket.PassengerId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FlightId,PassengerId,type")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FlightId = db.flights.Select(s => new SelectListItem
            {
                Value = s.id.ToString(),
                Text = s.source.city + " - " + s.destination.city + " on " + s.departureDate.ToString()
            });
            ViewBag.PassengerId = new SelectList(db.passengers, "id", "FullName", ticket.PassengerId);
            return View(ticket);
        }

        // GET: Tickets/Pay/5
        public ActionResult Pay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.tickets.Find(id);
            if (ticket == null)
            {
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // POST: Tickets/Pay/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pay([Bind(Include = "id")] Ticket ticket, string amountToPay)
        {
            if (ModelState.IsValid)
            {
                ticket.AmountPaid += Double.Parse(amountToPay);
                if (ticket.AmountPaid >= ticket.flight.ticketPrice)
                {
                    ticket.status = TicketStatusType.CONFIRMED;
                }
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.tickets.Find(id);
            ticket.status = TicketStatusType.CANCELLED;
            //db.tickets.Remove(ticket);
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
