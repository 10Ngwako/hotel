using Microsoft.AspNetCore.Mvc;  // Add this using directive
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleHotelBooking.Services;

namespace SimpleHotelBooking.Pages.Hotels
{
    public class VirtualTourModel : PageModel
    {
        private readonly HotelService _hotelService;
        
        public Models.Hotel? Hotel { get; set; }
        public List<string> TourImages { get; set; } = new();

        public VirtualTourModel(HotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public IActionResult OnGet(int id)  // This now has the correct type
        {
            Hotel = _hotelService.GetHotelById(id);
            
            if (Hotel == null)
            {
                return NotFound();
            }
            
            // Generate tour images based on hotel
            TourImages = GetTourImagesForHotel(Hotel);
            
            return Page();
        }
        
        private List<string> GetTourImagesForHotel(Models.Hotel hotel)
        {
            // Return placeholder 360° images
            // In a real app, you'd have actual hotel tour images
            return new List<string>
            {
                "https://images.unsplash.com/photo-1611892440504-42a792e24d32?ixlib=rb-1.2.1&auto=format&fit=crop&w=1200&q=80",
                "https://images.unsplash.com/photo-1566073771259-6a8506099945?ixlib=rb-1.2.1&auto=format&fit=crop&w=1200&q=80",
                "https://images.unsplash.com/photo-1584132967334-10e028bd69f7?ixlib=rb-1.2.1&auto=format&fit=crop&w=1200&q=80",
                "https://images.unsplash.com/photo-1590490360182-c33d57733427?ixlib=rb-1.2.1&auto=format&fit=crop&w=1200&q=80"
            };
        }
    }
}