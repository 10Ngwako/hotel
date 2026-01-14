using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleHotelBooking.Data;
using SimpleHotelBooking.Models;

namespace SimpleHotelBooking.Pages.Hotels
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hotel Hotel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Hotel = await _context.Hotels.FindAsync(id);
            if (Hotel == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
