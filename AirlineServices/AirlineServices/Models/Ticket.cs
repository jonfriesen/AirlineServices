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


        private double amountPaid = 0.0;
        [Display(Name = "Amount Paid")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public double AmountPaid
        {
            get
            {
                return amountPaid;
            }
            set
            {
                amountPaid = value;
            }
        }

        // Extended Properties
        [Display(Name = "Amount Due")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public double AmountDue
        {
            get
            {
                return (flight == null) ? 0.0 : flight.ticketPrice - AmountPaid;
            }
        }

        [Display(Name = "Refund Amount")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public double RefundAmount
        {
            get
            {
                //TODO 
                return 0.0;
            }
        }

    }
}