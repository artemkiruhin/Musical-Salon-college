using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Sales
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Sale Sale { get; set; }

        public IActionResult OnGet(int id) {
            var api = new SalesController();
            Sale = api.GetById(id);

            if (Sale == null)
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

            var api = new SalesController();
            api.Edit(Sale);

            return RedirectToPage("Index");
        }
    }
}
