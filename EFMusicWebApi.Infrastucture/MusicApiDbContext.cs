using Microsoft.EntityFrameworkCore;
using MusicWebApi.App.Models;

namespace EFMusicWebApi.Infrastucture
{
    public class MusicApiDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
    }
}
