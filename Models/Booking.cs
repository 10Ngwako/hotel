namespace SimpleHotelBooking.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string HotelName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public System.DateTime CheckInDate { get; set; }
        public System.DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = "Confirmed";
        public System.DateTime BookingDate { get; set; } = System.DateTime.Now;
        public string SpecialRequests { get; set; } = string.Empty;
        
        // Guest information - updated names to match your code
        public string CustomerName { get; set; } = string.Empty;  // Was GuestName
        public string CustomerPhone { get; set; } = string.Empty; // Was GuestPhone
        public string CustomerEmail { get; set; } = string.Empty; // Was GuestEmail
        
        // Added to match your existing code
        public int RoomsBooked { get; set; } = 1;
        public string Hotel { get; set; } = string.Empty; // Hotel name or details
    }
}