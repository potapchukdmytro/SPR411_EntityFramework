using _01_intro.Entities;
using Microsoft.EntityFrameworkCore;

namespace _01_intro
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;Database=SPR411;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // CategoryEntity configuration
            builder.Entity<CategoryEntity>()
                .HasKey(c => c.Id);

            builder.Entity<CategoryEntity>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Entity<CategoryEntity>()
                .Property(c => c.ImageUrl)
                .HasMaxLength(255);
        }
    }
}