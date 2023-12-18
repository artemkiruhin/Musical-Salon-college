namespace MusicalSalon.Domain.Models {
    public class Receipt {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime RecieveDate { get; set; }
        public int ProviderId { get; set; }
        public int Quantity { get; set; }
        public decimal FullPrice { get; set; }
    }
}
