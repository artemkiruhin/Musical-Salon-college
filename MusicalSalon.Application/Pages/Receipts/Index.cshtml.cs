using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Receipts
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Receipt> Receipts { get; set; }

        public void OnGet(string sortOrder) {
            var api = new ReceiptsController();
            Receipts = api.GetAll();

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
                case "providerId":
                    Receipts = Receipts.OrderBy(receipt => receipt.ProviderId).ToList();
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
