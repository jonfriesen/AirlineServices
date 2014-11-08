using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AirlineServices.Models
{
    public class Plane
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int tailNumber { get; set; }
        public int firstClassCapacity { get; set; }
        public int coachCapacity { get; set; }
        public int economyCapacity { get; set; }
    }
}