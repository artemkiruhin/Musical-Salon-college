using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Application.ViewModels;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Receipts
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public ReceiptViewModel Receipt { get; set; }

        public IActionResult OnGet(int id) {
            var api = new ReceiptsController();
            var r = api.GetById(id);
            Receipt = new ReceiptViewModel()
            {
                Id = r.Id,
                FullPrice = r.FullPrice,
                Number = r.Number,
                ProviderName = new ProvidersController().GetById(r.ProviderId).Name,
                Quantity = r.Quantity,
                RecieveDate = r.RecieveDate
            };

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
            var receiptToEdit = new Receipt()
            {
                Id = Receipt.Id,
                RecieveDate = Receipt.RecieveDate,
                FullPrice = Receipt.FullPrice,
                Number = Receipt.Number,
                ProviderId = new ProvidersController().GetAll().FirstOrDefault(p => p.Id == int.Parse(Receipt.ProviderName)).Id,
                Quantity = Receipt.Quantity
            };
            api.Edit(receiptToEdit);

            return RedirectToPage("Index");
        }
    }
}
