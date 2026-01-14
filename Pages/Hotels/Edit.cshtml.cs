using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleHotelBooking.Data;
using SimpleHotelBooking.Models;

namespace SimpleHotelBooking.Pages.Hotels
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Attach(Hotel).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(Hotel.Id))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToPage("Index");
        }

        private bool HotelExists(int id) => _context.Hotels.Any(h => h.Id == id);
    }
}
