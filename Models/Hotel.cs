namespace SimpleHotelBooking.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public decimal Rating { get; set; }
        public string ImageUrl { get; set; } = "/images/hotel-placeholder.jpg";
        public List<string> Amenities { get; set; } = new();
        
        // Hotel contact info
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        
        // Added to match your existing code
        public int TotalRooms { get; set; }
    }
}