using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Musicians
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Musician> Musicians { get; set; }

        public void OnGet(string sortOrder) {
            var api = new MusiciansController();
            Musicians = api.GetAll();

            switch (sortOrder)
            {
                case "id":
                    Musicians = Musicians.OrderBy(musician => musician.Id).ToList();
                    break;
                case "name":
                    Musicians = Musicians.OrderBy(musician => musician.Name).ToList();
                    break;
                case "careerYear":
                    Musicians = Musicians.OrderBy(musician => musician.CareerYear).ToList();
                    break;
                default:
                    Musicians = Musicians.OrderBy(musician => musician.Id).ToList();
                    break;
            }
        }


        public IActionResult OnPostDelete(int id) {
            var api = new MusiciansController();
            api.Delete(id);
            return RedirectToPage();
        }
    }
}
