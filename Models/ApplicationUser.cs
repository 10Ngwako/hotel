using Microsoft.AspNetCore.Identity;

namespace SimpleHotelBooking.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Optional extra properties
        public string FullName { get; set; }
    }
}
