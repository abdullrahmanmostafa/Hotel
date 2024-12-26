using hotel.Models;

public class BookingService
{
    public int BookingServiceId { get; set; }  // Primary Key
    public int BookingId { get; set; }  // Foreign Key to Booking
    public int ServiceId { get; set; }  // Foreign Key to Service
    public decimal Price { get; set; }  // Price for the service

    public Booking ?Booking { get; set; }
    public Service ?Service { get; set; }
}
