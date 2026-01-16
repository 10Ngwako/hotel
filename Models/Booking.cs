using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SimpleHotelBooking.Models
{
    public class Booking
    {
        public int Id { get; set; }
        
        [Required]
        public int HotelId { get; set; }
        
        [Required]
        public string HotelName { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; } = string.Empty;
        
        [Required]
        public DateTime CheckInDate { get; set; }
        
        [Required]
        public DateTime CheckOutDate { get; set; }
        
        [Range(1, 10)]
        public int NumberOfGuests { get; set; } = 1;
        
        [Range(1, 10000)]
        public decimal TotalPrice { get; set; }
        
        public string Status { get; set; } = "Confirmed";
        public DateTime BookingDate { get; set; } = DateTime.Now;
        
        public string SpecialRequests { get; set; } = string.Empty;
        
        // Guest information
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        
        public string CustomerPhone { get; set; } = string.Empty;
        
        [EmailAddress]
        public string CustomerEmail { get; set; } = string.Empty;
        
        // Navigation property
        public Hotel? Hotel { get; set; }
        
        // Helper method to parse decimal from string (handles comma decimal separator)
        public static decimal ParseDecimal(string value)
        {
            if (string.IsNullOrEmpty(value)) return 0;
            
            // Try parsing with current culture first
            if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out var result))
                return result;
            
            // Try with invariant culture (dot as decimal separator)
            if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
                return result;
            
            // Try replacing comma with dot
            var normalized = value.Replace(',', '.');
            if (decimal.TryParse(normalized, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
                return result;
                
            return 0;
        }
    }
}