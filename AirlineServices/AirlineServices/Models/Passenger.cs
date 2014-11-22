using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AirlineServices.Models
{
    public class Passenger : Person 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("PassengerId")]
        public virtual ICollection<Ticket> tickets { get; set; }

        private DateTime createDate = DateTime.Now;

        public DateTime CreateDate { get { return createDate; } set { lastModified = createDate; } }


        private DateTime lastModified = DateTime.Now;

        public DateTime LastModified { get { return lastModified; } set { lastModified = DateTime.Now; } }

        public bool hasActiveTickets()
        {
            var activeTickets = tickets.Where(s => s.status == TicketStatusType.BOOKED || s.status == TicketStatusType.CONFIRMED).ToList();
            return (activeTickets.Count > 0);
        }
    }
}