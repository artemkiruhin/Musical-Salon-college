using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Genres
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Genre Genre { get; set; }

        public IActionResult OnGet(int id) {
            var api = new GenresController();

            Genre = api.GetById(id);

            if (Genre == null)
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
            var api = new GenresController();

            api.Edit(Genre);

            return RedirectToPage("Index");
        }
    }
}
