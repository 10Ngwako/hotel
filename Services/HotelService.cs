using SimpleHotelBooking.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleHotelBooking.Services
{
    public class HotelService
    {
        private readonly List<Hotel> _hotels = new()
        {
            new Hotel
            {
                Id = 1,
                Name = "PALAZZO DI BORGO",
                Location = "Milan, Italy",
                Description = "Luxury hotel in the heart of Milan with stunning architecture and premium amenities.",
                PricePerNight = 299.99m,
                Rating = 4.8m,
                ImageUrl = "https://images.unsplash.com/photo-1566073771259-6a8506099945?ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=80",
                Amenities = "Free WiFi, Swimming Pool, Spa, Restaurant, Parking", // Changed to string
                Phone = "+39 02 1234567",
                Email = "info@palazzodiborgo.com",
                Address = "Via Montenapoleone 1, 20121 Milan, Italy"
            },
            new Hotel
            {
                Id = 2,
                Name = "BANCA DI BRESCIA",
                Location = "Brescia, Italy",
                Description = "Historic building converted into a boutique hotel with modern comforts.",
                PricePerNight = 189.99m,
                Rating = 4.5m,
                ImageUrl = "https://images.unsplash.com/photo-1611892440504-42a792e24d32?ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=80",
                Amenities = "Free WiFi, Breakfast Included, Bar, Conference Rooms", // Changed to string
                Phone = "+39 030 1234567",
                Email = "reservations@bancadibresciahotel.com",
                Address = "Piazza della Loggia 12, 25121 Brescia, Italy"
            },
            new Hotel
            {
                Id = 3,
                Name = "HOTEL PALAZZO DI BORGO",
                Location = "Rome, Italy",
                Description = "Elegant hotel near Vatican City with panoramic views and excellent service.",
                PricePerNight = 249.99m,
                Rating = 4.7m,
                ImageUrl = "https://images.unsplash.com/photo-1584132967334-10e028bd69f7?ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=80",
                Amenities = "Free WiFi, Roof Terrace, Fitness Center, Airport Shuttle", // Changed to string
                Phone = "+39 06 1234567",
                Email = "bookings@hotelpalazzodiborgo.com",
                Address = "Via della Conciliazione 10, 00193 Rome, Italy"
            }
        };

        public List<Hotel> GetAllHotels() => _hotels;
        
        public Hotel? GetHotelById(int id) => _hotels.FirstOrDefault(h => h.Id == id);
        
        public List<Hotel> SearchHotels(string location)
        {
            if (string.IsNullOrEmpty(location))
                return _hotels;
                
            return _hotels.Where(h => 
                h.Location.Contains(location, StringComparison.OrdinalIgnoreCase) ||
                h.Name.Contains(location, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        
        // Helper method to convert amenities string to list
        public List<string> GetAmenitiesList(Hotel hotel)
        {
            if (string.IsNullOrEmpty(hotel.Amenities))
                return new List<string>();
                
            return hotel.Amenities
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .ToList();
        }
    }
}