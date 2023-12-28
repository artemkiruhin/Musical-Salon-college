using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicalSalon.Application.Pages.Songs {
    public class IndexModel : PageModel {
        public IEnumerable<Song> Songs { get; set; }
        public string CurrentSort { get; set; }

        public void OnGet(string sortOrder) {
            var api = new SongsController();
            Songs = api.GetAll();

            switch (sortOrder)
            {
                case "id":
                    Songs = Songs.OrderBy(song => song.Id).ToList();
                    break;
                case "title":
                    Songs = Songs.OrderBy(song => song.Title).ToList();
                    break;
                case "musicianId":
                    Songs = Songs.OrderBy(song => song.MusicianId).ToList();
                    break;
                case "genreId":
                    Songs = Songs.OrderBy(song => song.GenreId).ToList();
                    break;
                case "releaseYear":
                    Songs = Songs.OrderBy(song => song.ReleaseYear).ToList();
                    break;
                default:
                    Songs = Songs.OrderBy(song => song.Id).ToList();
                    break;
            }
        }

        public IActionResult OnPostDelete(int id) {
            var api = new SongsController();
            api.Delete(id);
            return RedirectToPage("Index");
        }
    }
}
