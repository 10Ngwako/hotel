using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleHotelBooking.Services;

namespace SimpleHotelBooking.Pages.Hotels
{
    public class IndexModel : PageModel
    {
        private readonly HotelService _hotelService;
        
        public List<Models.Hotel> Hotels { get; set; } = new();

        public IndexModel(HotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public void OnGet()
        {
            Hotels = _hotelService.GetAllHotels();
        }
    }
}