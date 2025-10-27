using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicWebApi.App.Models;

namespace EFMusicWebApi.Infrastucture.Services
{
    public class MusicService
    {
        private readonly MusicApiDbContext _context;
        private readonly ILogger _logger;

        public MusicService(MusicApiDbContext context, ILogger<MusicService> logger)
        {
            _logger = logger;
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

        public void UpdateArtist(int id, Artist newArtist)
        {
            var artist = _context.Artists.FirstOrDefault(a => a.Id == id);

            if (artist != null)
            {
                artist.Name = newArtist.Name;

                artist.Age = newArtist.Age;
            }

            //_context.Entry(newArtist).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public void UpdateSong(int id, Song newSong)
        {
            var song = _context.Songs.FirstOrDefault(s => s.Id == id);

            if (song != null)
            {
                song.Title = newSong.Title;

                song.AlbumName = newSong.AlbumName;
            }

            //_context.Entry(newSong).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public void DeleteArtist(int id)
        {
            _context.Artists.Where(s => s.Id == id).ExecuteDelete();
        }

        public void DeleteSong(int id)
        {
            _context.Songs.Where(s => s.Id == id).ExecuteDelete();
        }
    }
}
