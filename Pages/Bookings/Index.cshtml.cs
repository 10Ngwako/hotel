using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleHotelBooking.Data;
using SimpleHotelBooking.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleHotelBooking.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Booking> Bookings { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // IMPORTANT: Include the Hotel navigation property
            Bookings = await _context.Bookings
                .Include(b => b.Hotel) // This loads the related hotel data
                .OrderByDescending(b => b.BookingDate)
                .ToListAsync();
        }
    }
}