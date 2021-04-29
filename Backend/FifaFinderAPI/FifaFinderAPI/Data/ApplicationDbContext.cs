using FifaFinderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FifaFinderAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Post> Posts { get; set; }
    }
}
