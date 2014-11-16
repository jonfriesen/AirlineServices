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
        public virtual Flight flight { get; set; }

        [Display(Name = "Passenger")]
        public int? PassengerId { get; set; }
        [ForeignKey("PassengerId")]
        public virtual Passenger passenger { get; set; }

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
                return (flight == null) ? -1.0 : TicketClassPrice - AmountPaid;
            }
        }

        [Display(Name = "Refund Amount")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public double RefundAmount
        {
            get
            {
                var randomValue = (flight == null) ? -1.0 : (flight.ticketPrice * 1);
                // Return 0 if they are economy and the flight is less than 2 weeks away
                var departingDate = (flight == null) ? DateTime.Now : flight.departureDate;
                if (type == TicketType.ECONOMY && (departingDate - DateTime.Now).TotalDays > 14)
                {
                    return 0.0;
                }
                return AmountPaid;
            }
        }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public double TicketClassPrice
        {
            get
            {
                double modifier = ((double)type / 100.00);
                return (flight == null) ? -1.0 : (flight.ticketPrice * modifier);
            }
        }
    }
}