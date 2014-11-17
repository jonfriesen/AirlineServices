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
        public ICollection<Ticket> tickets { get; set; }

        private DateTime createDate = DateTime.Now;

        public DateTime CreateDate { get { return createDate; } set { lastModified = createDate; } }


        private DateTime lastModified = DateTime.Now;

        public DateTime LastModified { get { return lastModified; } set { lastModified = DateTime.Now; } }
    }
}