using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Genres
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public void OnGet(string sortOrder) {
            var api = new GenresController();
            Genres = api.GetAll();

            switch (sortOrder)
            {
                case "id":
                    Genres = Genres.OrderBy(genre => genre.Id).ToList();
                    break;
                case "name":
                    Genres = Genres.OrderBy(genre => genre.Name).ToList();
                    break;
                default:
                    
                    Genres = Genres.OrderBy(genre => genre.Id).ToList();
                    break;
            }
        }
        public IActionResult OnPostDelete(int id) {
            var api = new GenresController();
            api.Delete(id);

            return RedirectToPage();
        }
    }
}
