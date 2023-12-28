using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Sales
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Sale Sale { get; set; }

        public IActionResult OnPost() {
            if (ModelState.IsValid)
            {
                var api = new SalesController();
                api.Add(Sale);
                
            }

            return RedirectToPage("Index");
        }
    }
}
