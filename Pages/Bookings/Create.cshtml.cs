using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleHotelBooking.Data;
using SimpleHotelBooking.Models;

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
            if (!ModelState.IsValid)
            {
                Hotels = await _context.Hotels.ToListAsync();
                return Page();
            }

            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
