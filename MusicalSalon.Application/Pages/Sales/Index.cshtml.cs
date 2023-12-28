using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Sales
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Sale> Sales { get; set; }

        public void OnGet(string sortOrder) {
            
            var api = new SalesController();
            Sales = api.GetAll();

            switch (sortOrder)
            {
                case "id":
                    Sales = Sales.OrderBy(sale => sale.Id).ToList();
                    break;
                case "diskid":
                    Sales = Sales.OrderBy(sale => sale.Diskid).ToList();
                    break;
                case "saleDate":
                    Sales = Sales.OrderBy(sale => sale.SaleDate).ToList();
                    break;
                case "quantity":
                    Sales = Sales.OrderBy(sale => sale.Quantity).ToList();
                    break;
                case "fullPrice":
                    Sales = Sales.OrderBy(sale => sale.FullPrice).ToList();
                    break;
                default:
                    Sales = Sales.OrderBy(sale => sale.Id).ToList();
                    break;
            }
        }

        public IActionResult OnPostDelete(int id) {

            var api = new SalesController();
            api.Delete(id);

            return RedirectToPage();
        }
    }
}
