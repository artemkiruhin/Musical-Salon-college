using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Application.ViewModels;
using MusicalSalon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicalSalon.Application.Pages.Songs {
    public class IndexModel : PageModel {
        public IEnumerable<SongViewModel> Songs { get; set; }
        public string CurrentSort { get; set; }

        public void OnGet(string sortOrder) {
            var api = new SongsController();
            var songs = api.GetAll();
            Songs = songs
                .Select(s => new SongViewModel()
                {
                    Id = s.Id,
                    Title = s.Title,
                    ReleaseYear = s.ReleaseYear,
                    GenreName = new GenresController().GetById(s.GenreId).Name,
                    MusicianName = new MusiciansController().GetById(s.MusicianId).Name
                })
                .ToList();

            switch (sortOrder)
            {
                case "id":
                    Songs = Songs.OrderBy(song => song.Id).ToList();
                    break;
                case "title":
                    Songs = Songs.OrderBy(song => song.Title).ToList();
                    break;
                case "musicianName":
                    Songs = Songs.OrderBy(song => song.MusicianName).ToList();
                    break;
                case "genreName":
                    Songs = Songs.OrderBy(song => song.GenreName).ToList();
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
