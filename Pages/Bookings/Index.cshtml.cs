using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleHotelBooking.Services;
using System.Collections.Generic;

namespace SimpleHotelBooking.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly BookingService _bookingService;
        public List<Models.Booking> Bookings { get; set; } = new();

        public IndexModel(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public void OnGet()
        {
            // Get bookings for current user (in real app, use actual user email)
            var userEmail = HttpContext.Session.GetString("UserEmail") ?? "demo@example.com";
            Bookings = _bookingService.GetUserBookings(userEmail);
            
            // For demo, add some bookings if none exist
            if (Bookings.Count == 0)
            {
                Bookings = new List<Models.Booking>
                {
                    new Models.Booking
                    {
                        Id = 1,
                        Hotel = "PALAZZO DI BORGO",
                        CustomerName = "John Doe",
                        CustomerEmail = userEmail,
                        CheckInDate = System.DateTime.Now.AddDays(7),
                        CheckOutDate = System.DateTime.Now.AddDays(10),
                        RoomsBooked = 2,
                        TotalPrice = 899.97m,
                        Status = "Confirmed"
                    }
                };
            }
        }
    }
}