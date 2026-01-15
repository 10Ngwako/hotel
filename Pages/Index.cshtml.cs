using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleHotelBooking.Services;
using System.Collections.Generic;

namespace SimpleHotelBooking.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HotelService _hotelService;
        
        public List<Models.Hotel> FeaturedHotels { get; set; } = new();
        public string UserName { get; set; } = string.Empty;

        public IndexModel(HotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public void OnGet()
        {
            // Get user name from session
            UserName = HttpContext.Session.GetString("UserName") ?? string.Empty;
            
            // Get featured hotels (top 3 by rating or manually selected)
            var allHotels = _hotelService.GetAllHotels();
            FeaturedHotels = allHotels
                .OrderByDescending(h => h.Rating)
                .Take(3)
                .ToList();
                
            // If HotelService doesn't have enough hotels, create some featured ones
            if (FeaturedHotels.Count < 3)
            {
                FeaturedHotels = new List<Models.Hotel>
                {
                    new Models.Hotel
                    {
                        Id = 1,
                        Name = "PALAZZO DI BORGO",
                        Location = "Milan, Italy",
                        Description = "Luxury hotel in the heart of Milan with stunning architecture",
                        PricePerNight = 299.99m,
                        Rating = 4.8m,
                        ImageUrl = "https://images.unsplash.com/photo-1566073771259-6a8506099945?ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=80",
                        Amenities = "Free WiFi, Pool, Spa, Restaurant"
                    },
                    new Models.Hotel
                    {
                        Id = 2,
                        Name = "SEASIDE RESORT",
                        Location = "Miami, USA",
                        Description = "Beachfront resort with private beach and tropical gardens",
                        PricePerNight = 279.99m,
                        Rating = 4.6m,
                        ImageUrl = "https://images.unsplash.com/photo-1584132967334-10e028bd69f7?ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=80",
                        Amenities = "Private Beach, Pools, Water Sports"
                    },
                    new Models.Hotel
                    {
                        Id = 3,
                        Name = "GRAND PLAZA HOTEL",
                        Location = "New York, USA",
                        Description = "Modern luxury hotel in Manhattan with spectacular city views",
                        PricePerNight = 399.99m,
                        Rating = 4.9m,
                        ImageUrl = "https://images.unsplash.com/photo-1611892440504-42a792e24d32?ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=80",
                        Amenities = "Rooftop Bar, Spa, 24/7 Room Service"
                    }
                };
            }
        }
    }
}