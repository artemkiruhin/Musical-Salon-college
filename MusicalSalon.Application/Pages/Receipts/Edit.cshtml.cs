using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Receipts
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Receipt Receipt { get; set; }

        public IActionResult OnGet(int id) {
            var api = new ReceiptsController();
            Receipt = api.GetById(id);

            if (Receipt == null)
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

            var api = new ReceiptsController();
            api.Edit(Receipt);

            return RedirectToPage("Index");
        }
    }
}
