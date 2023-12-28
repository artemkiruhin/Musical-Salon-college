using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Disks
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Disk> Disks { get; set; }
        
        public void OnGet(string sortOrder) {
            var api = new DisksController();
            Disks = api.GetAll();

            switch (sortOrder)
            {
                case "id":
                    Disks = Disks.OrderBy(disk => disk.Id).ToList();
                    break;
                case "songId":
                    Disks = Disks.OrderBy(disk => disk.SongId).ToList();
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
