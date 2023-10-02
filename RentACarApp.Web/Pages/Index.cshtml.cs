using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentACarApp.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        // Example: Define a model for a car
        public class Car
        {
            public string Make { get; set; }
            public string Model { get; set; }
            public string Description { get; set; }
            public decimal PricePerDay { get; set; }
            public string ImageUrl { get; set; }
        }

        // Example: Create a list of featured cars (you can replace this with your data source)
        public List<Car> FeaturedCars { get; set; }

        public void OnGet()
        {
            // Example: Populate the list of featured cars (you can replace this with data retrieval logic)
            FeaturedCars = new List<Car>
            {
                new Car { Make = "Toyota", Model = "Camry", Description = "A comfortable sedan for your trip.", PricePerDay = 50.0M, ImageUrl = "/images/toyota-camry.jpg" },
                new Car { Make = "Ford", Model = "Mustang", Description = "Experience the thrill of a sports car.", PricePerDay = 80.0M, ImageUrl = "/images/ford-mustang.jpg" },
                new Car { Make = "Honda", Model = "Civic", Description = "A fuel-efficient option for city driving.", PricePerDay = 45.0M, ImageUrl = "/images/honda-civic.jpg" }
            };
        }

    }
}