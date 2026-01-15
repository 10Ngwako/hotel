using System.ComponentModel.DataAnnotations;

namespace SimpleHotelBooking.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Location { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        [Range(1, 10000)]
        public decimal PricePerNight { get; set; }
        
        [Range(1, 5)]
        public decimal Rating { get; set; }
        public int TotalRooms { get; set; } = 50;
        
        
        public string ImageUrl { get; set; } = "/images/hotel-placeholder.jpg";
        
        // For database, store amenities as JSON or separate table
        public string Amenities { get; set; } = string.Empty; // Store as JSON string
        
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        
        // Navigation property for bookings
        public List<Booking> Bookings { get; set; } = new();
    }
}
