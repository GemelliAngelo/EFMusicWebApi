namespace MusicWebApi.App.Models
{
    public class Song
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string AlbumName{ get; set; }
    }
}
