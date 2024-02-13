using Microsoft.EntityFrameworkCore;
using SongListApi.Models;

namespace SongListApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
