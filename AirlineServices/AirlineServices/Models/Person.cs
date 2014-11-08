using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AirlineServices.Models
{
    public abstract class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string givenName { get; set; }
        public string familyName { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public DateTime birthdate { get; set; }
    }
}