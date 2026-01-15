using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleHotelBooking.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleHotelBooking.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<Models.Booking> Bookings { get; set; } = new();

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            // Get current user email from session
            var userEmail = HttpContext.Session.GetString("UserEmail") ?? "demo@example.com";
            
            // Try CustomerEmail first, then UserEmail if CustomerEmail is empty
            Bookings = await _context.Bookings
                .Where(b => b.CustomerEmail == userEmail || b.UserEmail == userEmail)
                .OrderByDescending(b => b.BookingDate)
                .ToListAsync();
            
            // For demo, create sample booking if none exist
            if (Bookings.Count == 0)
            {
                var sampleHotel = await _context.Hotels.FirstOrDefaultAsync();
                
                if (sampleHotel != null)
                {
                    var sampleBooking = new Models.Booking
                    {
                        HotelId = sampleHotel.Id,
                        HotelName = sampleHotel.Name,
                        UserEmail = userEmail,        // Store in UserEmail
                        CustomerName = "John Doe",
                        CustomerEmail = userEmail,    // Also store in CustomerEmail
                        CustomerPhone = "123-456-7890",
                        CheckInDate = System.DateTime.Now.AddDays(7),
                        CheckOutDate = System.DateTime.Now.AddDays(10),
                        NumberOfGuests = 2,
                        TotalPrice = sampleHotel.PricePerNight * 3,
                        Status = "Confirmed",
                        BookingDate = System.DateTime.Now.AddDays(-2),
                        SpecialRequests = "Non-smoking room please"
                    };
                    
                    _context.Bookings.Add(sampleBooking);
                    await _context.SaveChangesAsync();
                    
                    Bookings = new List<Models.Booking> { sampleBooking };
                }
            }
        }
    }
}