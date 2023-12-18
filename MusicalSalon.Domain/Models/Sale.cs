namespace MusicalSalon.Domain.Models {
    public class Sale {
        public int Id { get; set; }
        public int Diskid { get; set; }
        public DateTime SaleDate { get; set; }
        public int Quantity { get; set; }
        public decimal FullPrice { get; set; }
    }
}
