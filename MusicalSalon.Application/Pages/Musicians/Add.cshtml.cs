using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Musicians
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Musician Musician { get; set; }

        public IActionResult OnPost() {
            if (ModelState.IsValid)
            {
                var api = new MusiciansController();
                api.Add(Musician);
               
            }
            return RedirectToPage("Index");
        }
    }
}
