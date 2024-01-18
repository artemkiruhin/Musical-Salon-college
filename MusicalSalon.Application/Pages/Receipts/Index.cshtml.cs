using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Application.ViewModels;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Receipts
{
    public class IndexModel : PageModel
    {
        public IEnumerable<ReceiptViewModel> Receipts { get; set; }

        public void OnGet(string sortOrder) {
            var api = new ReceiptsController();
            var receipts = api.GetAll();
            Receipts = receipts
                .Select(r => new ReceiptViewModel()
                {
                    Id = r.Id,
                    FullPrice = r.FullPrice,
                    Number = r.Number,
                    Quantity = r.Quantity,
                    RecieveDate = r.RecieveDate,
                    ProviderName = new ProvidersController().GetById(r.ProviderId).Name.ToString()
                })
                .ToList();



            switch (sortOrder)
            {
                case "id":
                    Receipts = Receipts.OrderBy(receipt => receipt.Id).ToList();
                    break;
                case "number":
                    Receipts = Receipts.OrderBy(receipt => receipt.Number).ToList();
                    break;
                case "recieveDate":
                    Receipts = Receipts.OrderBy(receipt => receipt.RecieveDate).ToList();
                    break;
                case "providerName":
                    Receipts = Receipts.OrderBy(receipt => receipt.ProviderName).ToList();
                    break;
                case "quantity":
                    Receipts = Receipts.OrderBy(receipt => receipt.Quantity).ToList();
                    break;
                case "fullPrice":
                    Receipts = Receipts.OrderBy(receipt => receipt.FullPrice).ToList();
                    break;
                default:
                    Receipts = Receipts.OrderBy(receipt => receipt.Id).ToList();
                    break;
            }
        }
        public IActionResult OnPostDelete(int id) {

            var api = new ReceiptsController();
            api.Delete(id);
            return RedirectToPage();
        }
    }
}
