using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Providers
{
    public class EditModel : PageModel
    {
        public Provider provider;
        public void OnGet(int id)
        {
            var api = new ProvidersController();
            provider = api.GetById(id);
        }

        public IActionResult OnPost(Provider provider) {
            var api = new ProvidersController();
            api.Edit(provider);

            return RedirectToPage("Index");
        }
    }
}
