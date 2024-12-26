// Models/Guest.cs
using System.ComponentModel.DataAnnotations;

namespace hotel.Models
{
    public class Guest
    {
        public int Id { get; set; }

        [Required]
        public string? FullName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? Phone { get; set; }

        // Navigation property for bookings
        public ICollection<Booking>? Bookings { get; set; }
    }
}
