using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Application.ViewModels;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Sales
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public SaleViewModel Sale { get; set; }
        public IEnumerable<DiskViewModel> Disks { get; set; }
        public IActionResult OnGet(int id) {
            Disks = new DisksController().GetAll().Select(d => new DiskViewModel() { Id = d.Id, Title = d.Title }).ToList();

            var api = new SalesController();
            var sale = api.GetById(id);
            Sale = new SaleViewModel()
            {
                Id = sale.Id,
                SaleDate = sale.SaleDate,
                FullPrice = sale.FullPrice,
                Quantity = sale.Quantity,
                DiskName = new DisksController().GetById(sale.Diskid).Title
            };

            if (Sale == null)
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

            var api = new SalesController();

            var saleToEdit = new Sale()
            {
                Id = Sale.Id,
                SaleDate = Sale.SaleDate,
                FullPrice = Sale.FullPrice,
                Quantity = Sale.Quantity,
                Diskid = new DisksController().GetAll().FirstOrDefault(d => d.Id == int.Parse(Sale.DiskName)).Id,
            };

            api.Edit(saleToEdit);

            return RedirectToPage("Index");
        }
    }
}
