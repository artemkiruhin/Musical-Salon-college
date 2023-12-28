using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Musicians
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Musician Musician { get; set; }

        public IActionResult OnGet(int id) {
            var api = new MusiciansController();
            Musician = api.GetById(id);

            if (Musician == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost() {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var api = new MusiciansController();
            api.Edit(Musician);

            return RedirectToPage("Index");
        }
    }
}
