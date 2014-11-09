using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AirlineServices.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int? FlightId { get; set; }
        [Required]
        [Display(Name = "Flight")]
        [ForeignKey("FlightId")]
        public Flight flight { get; set; }

        [Display(Name = "Passenger")]
        public int? PassengerId { get; set; }
        [ForeignKey("PassengerId")]
        public Passenger passenger { get; set; }

        [Required]
        [Display(Name = "Status")]
        public TicketStatusType status { get; set; }

        [Required]
        [Display(Name = "Class")]
        public TicketType type { get; set; }

    }
}