using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleHotelBooking.Data;
using SimpleHotelBooking.Models;

namespace SimpleHotelBooking.Pages.Hotels
{
    public class AllModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AllModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Hotel> Hotels { get; set; } = new();

        public async Task OnGetAsync()
        {
            Hotels = (await _context.Hotels.ToListAsync())
    .OrderByDescending(h => h.Rating)
    .ToList();

        }
    }
}
