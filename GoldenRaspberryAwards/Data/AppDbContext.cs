using GoldenRaspberryAwards.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenRaspberryAwards.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
