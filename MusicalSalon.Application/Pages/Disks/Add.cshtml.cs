using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Application.ViewModels;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Disks
{
    public class AddModel : PageModel
    {
        public DiskViewModel Disk { get; set; }
        public List<SongViewModel> Songs { get; set; }
        public void OnGet(int id)
        {
            var api = new DisksController();

            Songs = new SongsController().GetAll().Select(s => new SongViewModel() { Id = s.Id, Title = s.Title }).ToList();
        }

        public IActionResult OnPost(DiskViewModel disk) {
            var api = new DisksController();

            Console.WriteLine(disk.SongName);

            var diskToDatabase = new Disk()
            {
                SongId = new SongsController().GetAll().FirstOrDefault(s => s.Id == int.Parse(disk.SongName)).Id,
                Price = disk.Price
            };

            Console.WriteLine(diskToDatabase.SongId + " " + diskToDatabase.Price);
            
            api.Add(diskToDatabase);

            return RedirectToPage("Index");
        }
    }
}
