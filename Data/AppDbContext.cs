using Microsoft.EntityFrameworkCore;
using NoticiasEnriquecidas.Models;

namespace NoticiasEnriquecidas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
