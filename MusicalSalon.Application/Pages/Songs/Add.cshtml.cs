using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Application.ViewModels;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Songs
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public SongViewModel Song { get; set; }
        public IEnumerable<Musician> Musicians { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IActionResult OnGet() {
            Musicians = new MusiciansController().GetAll().ToList();
            Genres = new GenresController().GetAll().ToList();
            return Page();
        }
        public IActionResult OnPost() {
            if (ModelState.IsValid)
            {
                var api = new SongsController();
                var songToAdd= new Song()
                {
                    Id = Song.Id,
                    Title = Song.Title,
                    ReleaseYear = Song.ReleaseYear,
                    GenreId = new GenresController().GetAll().FirstOrDefault(g => g.Id == int.Parse(Song.GenreName)).Id,
                    MusicianId = new MusiciansController().GetAll().FirstOrDefault(m => m.Id == int.Parse(Song.MusicianName)).Id
                };
                api.Add(songToAdd);
                
            }

            return RedirectToPage("Index");
        }
    }
}
