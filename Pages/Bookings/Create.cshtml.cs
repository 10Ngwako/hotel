using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleHotelBooking.Data;
using SimpleHotelBooking.Models;
using System.Globalization;

namespace SimpleHotelBooking.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; } = new Booking();

        public IList<Hotel> Hotels { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Hotels = await _context.Hotels.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // MANUALLY HANDLE THE TotalPrice DECIMAL PARSING
            // This is needed because your culture uses comma (,) as decimal separator
            var totalPriceValue = Request.Form["Booking.TotalPrice"];
            if (!string.IsNullOrEmpty(totalPriceValue))
            {
                // First try parsing with current culture (comma decimal separator)
                if (decimal.TryParse(totalPriceValue, NumberStyles.Any, CultureInfo.CurrentCulture, out var parsedPrice))
                {
                    Booking.TotalPrice = parsedPrice;
                    ModelState.Remove("Booking.TotalPrice"); // Remove any validation error
                }
                // If that fails, try with invariant culture (dot decimal separator)
                else if (decimal.TryParse(totalPriceValue, NumberStyles.Any, CultureInfo.InvariantCulture, out parsedPrice))
                {
                    Booking.TotalPrice = parsedPrice;
                    ModelState.Remove("Booking.TotalPrice"); // Remove any validation error
                }
            }

            // Also handle HotelName - make sure it's set
            var hotelIdValue = Request.Form["Booking.HotelId"];
            if (!string.IsNullOrEmpty(hotelIdValue) && int.TryParse(hotelIdValue, out var hotelId))
            {
                var selectedHotel = await _context.Hotels.FindAsync(hotelId);
                if (selectedHotel != null && string.IsNullOrEmpty(Booking.HotelName))
                {
                    Booking.HotelName = selectedHotel.Name;
                    ModelState.Remove("Booking.HotelName"); // Remove any validation error
                }
            }

            // Now validate the model
            if (!ModelState.IsValid)
            {
                Hotels = await _context.Hotels.ToListAsync();
                return Page();
            }

            // Set additional properties
            Booking.BookingDate = DateTime.UtcNow;
            Booking.Status = "Confirmed";

            // Add to database
            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();
            
            return RedirectToPage("Index");
        }
    }
}