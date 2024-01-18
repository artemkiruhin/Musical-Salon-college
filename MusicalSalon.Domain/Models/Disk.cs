namespace MusicalSalon.Domain.Models {
    public class Disk {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SongId { get; set; }
        public decimal Price { get; set; }
    }
}
