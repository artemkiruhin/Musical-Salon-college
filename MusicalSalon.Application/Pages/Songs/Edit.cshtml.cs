using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Application.ViewModels;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Songs
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public SongViewModel Song { get; set; }
        public IEnumerable<Musician> Musicians { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public IActionResult OnGet(int id) {
            Musicians = new MusiciansController().GetAll().ToList();
            Genres = new GenresController().GetAll().ToList();
            var api = new SongsController();
            var song = api.GetById(id);
            Song = new SongViewModel()
            {
                Id = song.Id,
                Title = song.Title,
                ReleaseYear = song.ReleaseYear,
                GenreName = new GenresController().GetById(song.GenreId).Name,
                MusicianName = new MusiciansController().GetById(song.MusicianId).Name
            };

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
            var songToEdit = new Song()
            {
                Id = Song.Id,
                Title = Song.Title,
                ReleaseYear = Song.ReleaseYear,
                GenreId = new GenresController().GetAll().FirstOrDefault(g => g.Id == int.Parse(Song.GenreName)).Id,
                MusicianId = new MusiciansController().GetAll().FirstOrDefault(m => m.Id == int.Parse(Song.MusicianName)).Id
            };
            api.Edit(songToEdit);

            return RedirectToPage("Index");
        }
    }
}
