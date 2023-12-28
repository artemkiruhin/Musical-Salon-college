using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Genres
{
    public class AddModel : PageModel
    {
        public Genre Genre { get; set; }

        public void OnGet()
        {
        }


        public IActionResult OnPost(Genre genre) {

            var api = new GenresController();
            api.Add(genre);



            return RedirectToPage("Index");
        }
    }
}
