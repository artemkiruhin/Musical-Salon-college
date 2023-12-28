using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Disks
{
    public class AddModel : PageModel
    {
        public Disk Disk { get; set; }
        public void OnGet(int id)
        {
            var api = new DisksController();
            Disk = api.GetById(id);
        }

        public IActionResult OnPost(Disk disk) {
            var api = new DisksController();
            api.Add(disk);

            return RedirectToPage("Index");
        }
    }
}
