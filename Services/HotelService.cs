using SimpleHotelBooking.Models;

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
                ImageUrl = "/images/hotel1.jpg",
                Amenities = new List<string> { "Free WiFi", "Swimming Pool", "Spa", "Restaurant", "Parking" },
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
                ImageUrl = "/images/hotel2.jpg",
                Amenities = new List<string> { "Free WiFi", "Breakfast Included", "Bar", "Conference Rooms" },
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
                ImageUrl = "/images/hotel3.jpg",
                Amenities = new List<string> { "Free WiFi", "Roof Terrace", "Fitness Center", "Airport Shuttle" },
                Phone = "+39 06 1234567",
                Email = "bookings@hotelpalazzodiborgo.com",
                Address = "Via della Conciliazione 10, 00193 Rome, Italy"
            },
            new Hotel
            {
                Id = 4,
                Name = "GRAND PLAZA HOTEL",
                Location = "New York, USA",
                Description = "Modern luxury hotel in Manhattan with spectacular city views.",
                PricePerNight = 399.99m,
                Rating = 4.9m,
                ImageUrl = "/images/hotel4.jpg",
                Amenities = new List<string> { "Free WiFi", "Rooftop Bar", "Spa", "24/7 Room Service" },
                Phone = "+1 212-555-1234",
                Email = "reservations@grandplazany.com",
                Address = "123 Park Avenue, New York, NY 10017"
            },
            new Hotel
            {
                Id = 5,
                Name = "SEASIDE RESORT",
                Location = "Miami, USA",
                Description = "Beachfront resort with private beach access and tropical gardens.",
                PricePerNight = 279.99m,
                Rating = 4.6m,
                ImageUrl = "/images/hotel5.jpg",
                Amenities = new List<string> { "Private Beach", "Swimming Pools", "Water Sports", "Kids Club" },
                Phone = "+1 305-555-1234",
                Email = "info@seasidemiami.com",
                Address = "456 Ocean Drive, Miami, FL 33139"
            }
        };

        public List<Hotel> GetAllHotels() => _hotels;
        
        public Hotel? GetHotelById(int id) => _hotels.FirstOrDefault(h => h.Id == id);
        
        public List<Hotel> SearchHotels(string location, DateTime? checkIn, DateTime? checkOut)
        {
            var results = _hotels;
            
            if (!string.IsNullOrEmpty(location))
            {
                results = results.Where(h => 
                    h.Location.Contains(location, StringComparison.OrdinalIgnoreCase) ||
                    h.Name.Contains(location, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            
            return results;
        }
    }
}