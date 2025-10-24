using Microsoft.EntityFrameworkCore;
using MusicWebApi.App.Models;

namespace EFMusicWebApi.Infrastucture
{
    public class MusicApiDbContext : DbContext
    {
        public MusicApiDbContext(DbContextOptions<MusicApiDbContext> options) : base(options) { }

        public DbSet<Song> Songs { get; init; }
        public DbSet<Artist> Artists { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Song>().HasData([
                new { Id = 1, Title = "Hello", AlbumName= "25"},
                new { Id = 2, Title = "Goosebumps", AlbumName = "Birds in the Trap Sing McKnight" },
                new { Id = 3, Title = "Waka Waka", AlbumName = "Sale el sol" },
                ]);

            builder.Entity<Artist>().HasData([
                new() { Id = 1, Name = "Adele", Age = 37 },
                new() { Id = 2, Name = "Travis Scott", Age = 34 },
                new() { Id = 3, Name = "Shakira", Age = 48 }
                ]);
        }
    }
}
