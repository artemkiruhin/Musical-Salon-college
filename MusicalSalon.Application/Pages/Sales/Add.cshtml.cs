using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicalSalon.API.Controllers;
using MusicalSalon.Application.ViewModels;
using MusicalSalon.Domain.Models;

namespace MusicalSalon.Application.Pages.Sales
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public SaleViewModel Sale { get; set; }
        public IEnumerable<DiskViewModel> Disks { get; set; }

        public IActionResult OnGet() {
            Disks = new DisksController().GetAll().Select(d => new DiskViewModel() { Id = d.Id, Title = d.Title }).ToList();

            return Page();
        }
        public IActionResult OnPost() {
            if (ModelState.IsValid)
            {
                var api = new SalesController();
                var saleToAdd = new Sale()
                {
                    Id = Sale.Id,
                    SaleDate = Sale.SaleDate,
                    FullPrice = Sale.FullPrice,
                    Quantity = Sale.Quantity,
                    Diskid = new DisksController().GetAll().FirstOrDefault(d => d.Id == int.Parse(Sale.DiskName)).Id,
                };
                api.Add(saleToAdd);
                
            }

            return RedirectToPage("Index");
        }
    }
}
