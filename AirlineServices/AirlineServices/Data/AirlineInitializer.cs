using AirlineServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineServices.Data
{
    public class AirlineInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AirlineContext>
    {
        protected override void Seed(AirlineContext context)
        {
            //base.Seed(context);
            // Populate planes
            var planes = new List<Plane>
            {
                new Plane{tailNumber=7466, coachCapacity=120, economyCapacity=60, firstClassCapacity=20},
                new Plane{tailNumber=1233, coachCapacity=120, economyCapacity=60, firstClassCapacity=20},
                new Plane{tailNumber=1654, coachCapacity=120, economyCapacity=60, firstClassCapacity=20},
                new Plane{tailNumber=8644, coachCapacity=120, economyCapacity=60, firstClassCapacity=20},
            };
            planes.ForEach(s => context.planes.Add(s));
            context.SaveChanges();

            // Locations
            var locations = new List<Location>
            {
                new Location{airportCode="YVR", city="Vancouver", country="Canada"},
                new Location{airportCode="YXX", city="Abbotsford", country="Canada"},
                new Location{airportCode="YYZ", city="Toronto", country="Canada"},
                new Location{airportCode="LAS", city="Las Vegas", country="United States"},
            };

            locations.ForEach(s => context.locations.Add(s));
            context.SaveChanges();

            // Flights
            var flights = new List<Flight>
            {
                new Flight{plane=context.planes.First<Plane>(),
                    departureDate=DateTime.Today,
                    source=context.locations.Where(s => s.airportCode == "YVR").FirstOrDefault<Location>(),
                    destination=context.locations.Where(s => s.airportCode == "LAS").FirstOrDefault<Location>(),
                    ticketPrice=321.32,
                    tickets=null,
                    status=FlightStatusType.ONTIME
                }
            };

            flights.ForEach(s => context.flights.Add(s));
            context.SaveChanges();

            // Passengers
            var passengers = new List<Passenger>
            {
                new Passenger{tickets=new List<Ticket>{new Ticket{type=TicketType.FIRSTCLASS, status=TicketStatusType.BOOKED, flight=context.flights.First<Flight>()}},
                    givenName="Jon", familyName="Smith", phoneNumber="6045551234", address="123 Fake St. Fakeville", birthdate = new DateTime(1990, 06, 29), country="Canada"},
                new Passenger{tickets=new List<Ticket>{new Ticket{type=TicketType.FIRSTCLASS, status=TicketStatusType.BOOKED, flight=context.flights.First<Flight>()}},
                    givenName="Charles", familyName="Youds", phoneNumber="6045551234", address="123 Fake St. Fakeville", birthdate = new DateTime(1990, 06, 29), country="Canada"},
                new Passenger{tickets=new List<Ticket>{new Ticket{type=TicketType.FIRSTCLASS, status=TicketStatusType.BOOKED, flight=context.flights.First<Flight>()}},
                    givenName="Kurtis", familyName="Oosterhof", phoneNumber="6045551234", address="123 Fake St. Fakeville", birthdate = new DateTime(1990, 06, 29), country="Canada"},
                new Passenger{tickets=new List<Ticket>{new Ticket{type=TicketType.FIRSTCLASS, status=TicketStatusType.BOOKED, flight=context.flights.First<Flight>()}},
                    givenName="Ali", familyName="Mograbhi", phoneNumber="6045551234", address="123 Fake St. Fakeville", birthdate = new DateTime(1990, 06, 29), country="Canada"}
            };

            passengers.ForEach(s => context.passengers.Add(s));
            context.SaveChanges();
        }
    }
}