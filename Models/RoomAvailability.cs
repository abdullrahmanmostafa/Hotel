// Models/RoomAvailability.cs
using System;

namespace hotel.Models
{
    public class RoomAvailability
    {
        public int Id { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public DateTime Date { get; set; }

        public bool IsAvailable { get; set; }
    }
}
