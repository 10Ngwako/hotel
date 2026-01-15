using SimpleHotelBooking.Models;

namespace SimpleHotelBooking.Services
{
    public class BookingService
    {
        private readonly List<Booking> _bookings = new();
        private int _nextId = 1;

        public List<Booking> GetAllBookings() => _bookings;
        
        public List<Booking> GetUserBookings(string userEmail) => 
            _bookings.Where(b => b.UserEmail == userEmail).ToList();
        
        public Booking? GetBookingById(int id) => _bookings.FirstOrDefault(b => b.Id == id);
        
        public Booking CreateBooking(Booking booking)
        {
            booking.Id = _nextId++;
            booking.BookingDate = DateTime.Now;
            booking.Status = "Confirmed";
            _bookings.Add(booking);
            return booking;
        }
        
        public bool CancelBooking(int id)
        {
            var booking = GetBookingById(id);
            if (booking != null)
            {
                booking.Status = "Cancelled";
                return true;
            }
            return false;
        }
    }
}