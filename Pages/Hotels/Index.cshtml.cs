using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleHotelBooking.Data;
using SimpleHotelBooking.Models;

namespace SimpleHotelBooking.Pages.Hotels
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Hotel> Hotels { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Hotels = await _context.Hotels.ToListAsync();
        }
    }
}
