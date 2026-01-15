using Microsoft.EntityFrameworkCore;
using SimpleHotelBooking.Data;
using SimpleHotelBooking.Models;
using SimpleHotelBooking.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<HotelService>();
builder.Services.AddScoped<BookingService>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();

// SIMPLE database initialization
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    
    // Create database if it doesn''t exist
    dbContext.Database.EnsureCreated();
    
    // Try to add seed data (will fail gracefully if already exists)
    try
    {
        // Clear any existing data first
        dbContext.Hotels.RemoveRange(dbContext.Hotels);
        await dbContext.SaveChangesAsync();
        
        // Add sample hotels
        dbContext.Hotels.Add(new Hotel 
        { 
            Name = "PALAZZO DI BORGO", 
            Location = "Milan, Italy", 
            Description = "Luxury hotel in the heart of Milan",
            PricePerNight = 299.99m,
            Rating = 4.8m,
            TotalRooms = 50,
            ImageUrl = "https://images.unsplash.com/photo-1566073771259-6a8506099945?ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=80",
            Amenities = "Free WiFi, Swimming Pool, Spa, Restaurant, Parking",
            Phone = "+39 02 1234567",
            Email = "info@palazzodiborgo.com",
            Address = "Via Montenapoleone 1, 20121 Milan, Italy"
        });
        
        dbContext.Hotels.Add(new Hotel 
        { 
            Name = "BANCA DI BRESCIA", 
            Location = "Brescia, Italy", 
            Description = "Historic boutique hotel",
            PricePerNight = 189.99m,
            Rating = 4.5m,
            TotalRooms = 30,
            ImageUrl = "https://images.unsplash.com/photo-1611892440504-42a792e24d32?ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=80",
            Amenities = "Free WiFi, Breakfast Included, Bar, Conference Rooms",
            Phone = "+39 030 1234567",
            Email = "reservations@bancadibresciahotel.com",
            Address = "Piazza della Loggia 12, 25121 Brescia, Italy"
        });
        
        await dbContext.SaveChangesAsync();
        Console.WriteLine("? Database seeded successfully");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Note: {ex.Message}");
        // Continue - database is created even if seeding fails
    }
}

app.MapRazorPages();
app.Run();
