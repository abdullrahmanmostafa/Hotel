// Models/Booking.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace hotel.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public int GuestId { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        // Navigation properties
        public Room? Room { get; set; }
        public Guest? Guest { get; set; }

        // Foreign key for billing information
        public int? BillingId { get; set; }
        public Billing? Billing { get; set; }
    }
}
