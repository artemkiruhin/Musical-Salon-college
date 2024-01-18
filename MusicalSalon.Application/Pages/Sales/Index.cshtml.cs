using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Application.ViewModels;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Sales
{
    public class IndexModel : PageModel
    {
        public IEnumerable<SaleViewModel> Sales { get; set; }

        public void OnGet(string sortOrder) {
            
            var api = new SalesController();
            var sales = api.GetAll();
            Sales = sales
                .Select(s => new SaleViewModel()
                {
                    Id = s.Id,
                    FullPrice = s.FullPrice,
                    SaleDate = s.SaleDate,
                    Quantity = s.Quantity,
                    DiskName = new DisksController().GetById(s.Diskid).Title
                })
                .ToList();

            switch (sortOrder)
            {
                case "id":
                    Sales = Sales.OrderBy(sale => sale.Id).ToList();
                    break;
                case "diskName":
                    Sales = Sales.OrderBy(sale => sale.DiskName).ToList();
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
