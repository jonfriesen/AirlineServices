using AirlineServices.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirlineServices.ViewModels
{
    public class PayViewModel
    {
        public virtual Ticket ticket { get; set; }
        public double amountToPay = 0.0;
        [Display(Name = "Amount To Pay")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public double AmountToPay
        {
            get
            {
                return amountToPay;
            }
            set
            {
                amountToPay = value;
            }
        }
    }
}