using Microsoft.EntityFrameworkCore;
using PC_3.NoticiasEnriquecidas.Models;

namespace PC_3.NoticiasEnriquecidas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
