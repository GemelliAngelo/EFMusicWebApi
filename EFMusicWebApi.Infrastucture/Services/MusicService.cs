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
                return artists;

            return [_context.Artists.FirstOrDefault(s => s.Name == name)];
        }
        public List<Song>? GetSongs(string title = "")
        {
            if (string.IsNullOrEmpty(title))
                return [.. _context.Songs];

            return [_context.Songs.FirstOrDefault(s => s.Title == title)];
        }
    }
}
