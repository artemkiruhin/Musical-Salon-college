using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Receipts
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Receipt Receipt { get; set; }

        public void OnGet()
        {
        }
        
        public IActionResult OnPost() {
            var api = new ReceiptsController();
            if (ModelState.IsValid)
            {
                api.Add(Receipt);
            }

            return RedirectToPage("Index");

        }
    }
}
