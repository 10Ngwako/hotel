using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleHotelBooking.Data;
using SimpleHotelBooking.Models;

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
            Bookings = await _context.Bookings
                .Include(b => b.Hotel)
                .ToListAsync();
        }
    }
}
