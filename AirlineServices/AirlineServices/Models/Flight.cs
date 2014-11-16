﻿using System;
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
        [Display(Name = "Flight Id")]
        public int id { get; set; }

        public virtual Plane plane { get; set; }

        public virtual Location source { get; set; }

        public virtual Location destination { get; set; }

        [Required]
        [Display(Name="Departure Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode=true)]
        public DateTime departureDate { get; set; }

        [Required]
        [Display(Name = "Price")]
<<<<<<< HEAD
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "${0:N2}", ApplyFormatInEditMode = true)]
=======
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
>>>>>>> b9e2e98... Adding UI/UX changes
        public double ticketPrice { get; set; }

        [ForeignKey("FlightId")]
        public virtual ICollection<Ticket> tickets { get; set; }

        [Required]
        [Display(Name = "Status")]
        public FlightStatusType status { get; set; }
    }
}