using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Application.ViewModels;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Receipts
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public ReceiptViewModel Receipt { get; set; }
        public IEnumerable<Provider> Providers { get; set; }
        public IActionResult OnGet(int id) {
            Providers = new ProvidersController().GetAll().ToList();
            return Page();
        }
        
        public IActionResult OnPost() {
            var api = new ReceiptsController();
            if (ModelState.IsValid)
            {
                var receiptToAdd = new Receipt()
                {
                    Id = Receipt.Id,
                    RecieveDate = Receipt.RecieveDate,
                    FullPrice = Receipt.FullPrice,
                    Number = Receipt.Number,
                    ProviderId = new ProvidersController().GetAll().FirstOrDefault(p => p.Id == int.Parse(Receipt.ProviderName)).Id,
                    Quantity = Receipt.Quantity
                };

                api.Add(receiptToAdd);
            }

            return RedirectToPage("Index");

        }
    }
}
