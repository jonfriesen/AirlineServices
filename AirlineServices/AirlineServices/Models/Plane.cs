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
        [Required]
        [Display(Name = "Tail Number")]
        public int tailNumber { get; set; }

        [Required]
        [Display(Name = "Firt Class Capacity")]
        public int firstClassCapacity { get; set; }

        [Required]
        [Display(Name = "Coach Capacity")]
        public int coachCapacity { get; set; }

        [Required]
        [Display(Name = "Economy Capacity")]
        public int economyCapacity { get; set; }
    }
}