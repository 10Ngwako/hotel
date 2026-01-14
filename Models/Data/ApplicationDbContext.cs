using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleHotelBooking.Models;

namespace SimpleHotelBooking.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Hotel> Hotels => Set<Hotel>();
        public DbSet<Booking> Bookings => Set<Booking>();
    }
}
