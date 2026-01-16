using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace YourAppNamespace.Pages.Hotels
{
    public class SearchModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Location { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime CheckInDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime CheckOutDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public string HotelType { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Amenities { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Guests { get; set; } = 2;

        [BindProperty(SupportsGet = true)]
        public string PriceRange { get; set; }

        // TEMP: Fake data to prove it works
        public List<HotelResult> Results { get; set; }

        public void OnGet()
        {
            // If user lands here without searching
            if (string.IsNullOrWhiteSpace(Location))
            {
                Results = new List<HotelResult>();
                return;
            }

            // Fake search results (replace later with DB)
            Results = new List<HotelResult>
            {
                new HotelResult
                {
                    Id = 1,
                    Name = "Ocean Paradise Resort",
                    Location = Location,
                    PricePerNight = 399.99m,
                    Rating = 4.8m,
                    ImageUrl = "https://images.unsplash.com/photo-1584132967334-10e028bd69f7"
                },
                new HotelResult
                {
                    Id = 2,
                    Name = "Mountain Serenity Lodge",
                    Location = Location,
                    PricePerNight = 299.99m,
                    Rating = 4.6m,
                    ImageUrl = "https://images.unsplash.com/photo-1571896349842-33c89424de2d"
                }
            };
        }
    }

    public class HotelResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal PricePerNight { get; set; }
        public decimal Rating { get; set; }
        public string ImageUrl { get; set; }
    }
}
