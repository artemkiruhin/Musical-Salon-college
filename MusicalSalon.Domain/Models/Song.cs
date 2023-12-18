namespace MusicalSalon.Domain.Models {
    public class Song {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MusicianId { get; set; }
        public int GenreId { get; set; }
        public int ReleaseYear { get; set; }
    }
}
