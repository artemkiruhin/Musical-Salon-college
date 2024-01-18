using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Application.ViewModels;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Disks
{
    public class IndexModel : PageModel
    {
        public IEnumerable<DiskViewModel> Disks { get; set; }
        
        public void OnGet(string sortOrder) {
            var api = new DisksController();
            var disks = api.GetAll();

            Disks = disks
                .Select(d => new DiskViewModel()
                {
                    Id = d.Id,
                    Title = d.Title,
                    SongName = new SongsController().GetById(d.SongId).Title,
                    Price = d.Price
                })
                .ToList();



            switch (sortOrder)
            {
                case "id":
                    Disks = Disks.OrderBy(disk => disk.Id).ToList();
                    break;
                case "title":
                    Disks = Disks.OrderBy(disk => disk.Title).ToList();
                    break;
                case "songId":
                    Disks = Disks.OrderBy(disk => disk.SongName).ToList();
                    break;
                case "price":
                    Disks = Disks.OrderBy(disk => disk.Price).ToList();
                    break;
                default:
                    Disks = Disks.OrderBy(disk => disk.Id).ToList();
                    break;
            }
        }
        public IActionResult OnPost(int id) {
            var api = new DisksController();
            api.Delete(id);

            return RedirectToPage("Index");
        }
    }
}
