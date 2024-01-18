namespace MusicalSalon.Application.ViewModels {
    public class ReceiptViewModel {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime RecieveDate { get; set; }
        public string ProviderName { get; set; }
        public int Quantity { get; set; }
        public decimal FullPrice { get; set; }
    }
}
