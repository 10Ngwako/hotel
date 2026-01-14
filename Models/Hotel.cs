using System.ComponentModel.DataAnnotations;

namespace SimpleHotelBooking.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Hotel Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = string.Empty;

        [Range(1, 500)]
        [Display(Name = "Total Rooms")]
        public int TotalRooms { get; set; }

        [Range(0, double.MaxValue)]
        [Display(Name = "Price per Night")]
        public double PricePerNight { get; set; }
    }
}
