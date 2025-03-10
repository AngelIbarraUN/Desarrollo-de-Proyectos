using Creatisa.Models;
using Microsoft.EntityFrameworkCore;

namespace Creatisa.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        //public DbSet<YourEntity> YourEntities { get; set; }
        

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Additional configuration if needed
            // modelBuilder.Entity<YourEntity>().HasKey(e => e.Id);
        }
        */
    }
}