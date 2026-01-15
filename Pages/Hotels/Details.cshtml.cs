using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleHotelBooking.Services;

namespace SimpleHotelBooking.Pages.Hotels
{
    public class DetailsModel : PageModel
    {
        private readonly HotelService _hotelService;
        
        public Models.Hotel? Hotel { get; set; }

        public DetailsModel(HotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public IActionResult OnGet(int id)
        {
            Hotel = _hotelService.GetHotelById(id);
            
            if (Hotel == null)
            {
                return NotFound();
            }
            
            return Page();
        }
    }
}