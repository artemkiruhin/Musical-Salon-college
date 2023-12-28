using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Songs
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Song Song { get; set; }

        public IActionResult OnPost() {
            if (ModelState.IsValid)
            {
                var api = new SongsController();
                api.Add(Song);
                
            }

            return RedirectToPage("Index");
        }
    }
}
