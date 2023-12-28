using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Providers
{
    public class AddModel : PageModel
    {
        public Provider Provider { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Provider provider) {
            var api = new ProvidersController();
            api.Add(provider);

            return RedirectToPage("Index");
        }
    }
}
