// Models/Room.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hotel.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Range(1, 10000)]
        public decimal Price { get; set; }

        // Navigation property for reservations (room can have many bookings)
        public ICollection<Booking>? Bookings { get; set; }

        // Navigation property for room availability
        public ICollection<RoomAvailability>? RoomAvailabilities { get; set; }
    }
}
