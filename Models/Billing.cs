// Models/Billing.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace hotel.Models
{
    public class Billing
    {
        public int Id { get; set; }

        [Required]
        public decimal AmountDue { get; set; }

        [Required]
        public DateTime BillingDate { get; set; }

        [Required]
        public string? PaymentMethod { get; set; }

        // Navigation property for bookings
        public ICollection<Booking>? Bookings { get; set; }
    }
}
