namespace MusicalSalon.Application.ViewModels {
    public class SaleViewModel {
        public int Id { get; set; }
        public string DiskName { get; set; }
        public DateTime SaleDate { get; set; }
        public int Quantity { get; set; }
        public decimal FullPrice { get; set; }
    }
}
