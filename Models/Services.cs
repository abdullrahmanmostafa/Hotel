// Models/Service.cs
using System.ComponentModel.DataAnnotations;

namespace hotel.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        // Navigation property for bookings to track services used
        public ICollection<BookingService>? BookingServices { get; set; }
    }
}
