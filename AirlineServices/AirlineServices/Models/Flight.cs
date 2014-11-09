using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AirlineServices.Models
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public Plane plane { get; set; }

        public Location source { get; set; }

        public Location destination { get; set; }

        [Required]
        [Display(Name="Departure Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode=true)]
        public DateTime departureDate { get; set; }

        [Required]
        [Display(Name = "Price")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "${0:N2}", ApplyFormatInEditMode = true)]
        public double ticketPrice { get; set; }

        [ForeignKey("FlightId")]
        public virtual ICollection<Ticket> tickets { get; set; }

        [Required]
        [Display(Name = "Status")]
        public FlightStatusType status { get; set; }
    }
}