// Models/Reservation.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace hotel.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        // Navigation properties
        public Room ?Room { get; set; }
        public Guest ?Customer { get; set; }
    }
}
