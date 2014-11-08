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
        public int id { get; set; }
        public Plane plane { get; set; }
        public Location source { get; set; }
        public Location destination { get; set; }
        public DateTime departureDate { get; set; }
        public double ticketPrice { get; set; }
        [ForeignKey("FlightId")]
        public virtual ICollection<Ticket> tickets { get; set; }
        public FlightStatusType status { get; set; }
    }
}