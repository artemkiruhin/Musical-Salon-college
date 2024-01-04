using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Application.ViewModels;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Disks {
    public class EditModel : PageModel {
        public DiskViewModel Disk { get; set; }
        public List<SongViewModel> Songs { get; set; }
        public void OnGet(int id) {
            var api = new DisksController();
            var u = api.GetById(id);

            Songs = new SongsController().GetAll().Select(s => new SongViewModel() { Id = s.Id, Title = s.Title }).ToList();

            Disk = new DiskViewModel()
            {
                Id = u.Id,
                SongName = Songs.First(x => x.Id == u.SongId).Title,
                Price = u.Price
            };
                
        }

        public IActionResult OnPost(DiskViewModel disk) { 
            var api = new DisksController();

            var diskToDatabase = new Disk()
            {
                Id = disk.Id,
                SongId = new SongsController().GetAll().FirstOrDefault(s => s.Id == int.Parse(disk.SongName)).Id,
                Price = disk.Price
            };

            Console.WriteLine(diskToDatabase.SongId + " " + diskToDatabase.Price);


            api.Edit(diskToDatabase);

            return RedirectToPage("Index");
        }
    }
}
