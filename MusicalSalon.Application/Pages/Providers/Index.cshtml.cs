using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Providers
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Provider> Providers;
        
        public void OnGet(string sortOrder) {
            var api = new ProvidersController();
            Providers = api.GetAll();

            switch (sortOrder)
            {
                case "id":
                    Providers = Providers.OrderBy(provider => provider.Id).ToList();
                    break;
                case "name":
                    Providers = Providers.OrderBy(provider => provider.Name).ToList();
                    break;
                default:
                    Providers = Providers.OrderBy(provider => provider.Id).ToList();
                    break;
            }
        }

        public IActionResult OnPost(int id) {

            var api = new ProvidersController();
            api.Delete(id);

            return RedirectToPage("Index");
        }
    }
}
