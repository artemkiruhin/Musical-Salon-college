using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Songs
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Song Song { get; set; }

        public IActionResult OnGet(int id) {
            var api = new SongsController();
            Song = api.GetById(id);

            if (Song == null)
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
            var api = new SongsController();
            api.Edit(Song);

            return RedirectToPage("Index");
        }
    }
}
