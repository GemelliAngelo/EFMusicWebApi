using MusicWebApi.App.Models;

namespace EFMusicWebApi.Infrastucture.Services
{
    public class MusicService
    {
        private readonly MusicApiDbContext _context;

        public MusicService(MusicApiDbContext context)
        {
            _context = context;
        }

        public List<Artist>? GetArtists(string name = "")
        {
            var artists = _context.Artists.ToList();

            if (string.IsNullOrEmpty(name))
                return artists ?? artists;

            return [_context.Artists.FirstOrDefault(s => s.Name == name)];
        }
        public List<Song>? GetSongs(string title = "")
        {
            var songs = _context.Songs.ToList();

            if (string.IsNullOrEmpty(title))
                return songs ?? songs;

            return [_context.Songs.FirstOrDefault(s => s.Title == title)];
        }

        public void AddArtist(Artist artist)
        {
            _context.Artists.Add(artist);

            _context.SaveChanges();
        }

        public void AddSong(Song song)
        {
            _context.Songs.Add(song);

            _context.SaveChanges();
        }
    }
}
