using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentACarAppLibrary.Data;
using RentACarAppLibrary.Models;

namespace RentACarApp.Web.Pages
{
    public class BookCarModel : PageModel
    {
        private readonly IDatabaseData _db;

        [BindProperty(SupportsGet = true)]
        public int CarTypeId { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        public CarTypeModel CarType { get; set; }
        public BookCarModel(IDatabaseData db)
        {
            _db = db;
        }
        public void OnGet()
        {
            if (CarTypeId > 0)
            {
                CarType = _db.GetCarTypeById(CarTypeId);
            }
        }

        public IActionResult OnPost()
        {
            _db.RentCar(FirstName, LastName,StartDate,EndDate, CarTypeId);
            return RedirectToPage("/CarSearch");
        }
    }
}
