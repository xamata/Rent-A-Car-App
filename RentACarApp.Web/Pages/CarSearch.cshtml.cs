using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentACarAppLibrary.Data;
using RentACarAppLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace RentACarApp.Web.Pages
{
    public class CarSearchModel : PageModel
    {
        private readonly IDatabaseData _db;

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);
        [BindProperty(SupportsGet = true)]
        public bool SearchEnabled { get; set; }
        public List<CarTypeModel> AvailableCarTypes { get; set; }
        public CarSearchModel(IDatabaseData db)
        {
            _db = db;
        }
        public void OnGet()
        {
            if (SearchEnabled == true)
            {
                AvailableCarTypes = _db.GetAvailableCarTypes(StartDate, EndDate);
            }
        }

        public IActionResult OnPost()
        {
            return RedirectToPage(new
            {
                SearchEnabled = true,
                StartDate = StartDate.ToString("yyyy-MM-dd"),
                EndDate = EndDate.ToString("yyyy-MM-dd")
            });
        }
    }
}
