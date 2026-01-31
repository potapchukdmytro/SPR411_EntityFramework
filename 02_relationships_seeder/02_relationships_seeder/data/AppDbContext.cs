using _02_relationships_seeder.entites;
using Microsoft.EntityFrameworkCore;

namespace _02_relationships_seeder.data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;Database=SPR411_Shop;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Product
            builder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
                entity.Property(p => p.Description).HasColumnType("ntext");
            });

            // Category
            builder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
            });

            // User
            builder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(200);
                entity.Property(u => u.FirstName).HasMaxLength(100);
                entity.Property(u => u.LastName).HasMaxLength(100);
            });

            // Role
            builder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Name).IsRequired().HasMaxLength(100);
            });

            // Relationships
            // One-to-Many: Category - Products
            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // many-to-Many: Order - Products via OrderItem
            builder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ProductId });

            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            // One-to-Many: User - Orders
            builder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-Many: User - Roles
            builder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity("UserRoles");

            // seed
            //builder.Entity<Category>().HasData(
            //        new Category { Id = 1, Name = "Мобільні телефони" },
            //        new Category { Id = 2, Name = "Молочні продукти" },
            //        new Category { Id = 3, Name = "Хлібобулочні вироби" },
            //        new Category { Id = 4, Name = "Взуття" }
            //    );

            //builder.Entity<Product>().HasData(
            //    new Product { Name = "Iphone 15", Price = 1200.0d, Amount = 10, CategoryId = 1, Id = 1, CreatedDate = new DateTime(2026,1,31) },
            //    new Product { Name = "Samsung Galaxy S24", Price = 1000.0d, Amount = 15, CategoryId = 1, Id = 2, CreatedDate = new DateTime(2026, 1, 31) },
            //    new Product { Name = "Сир", Price = 33.0d, Amount = 65, CategoryId = 2, Id = 3, CreatedDate = new DateTime(2026, 1, 31) },
            //    new Product { Name = "Йогурт", Price = 25.0d, Amount = 15, CategoryId = 2, Id = 4, CreatedDate = new DateTime(2026, 1, 31) },
            //    new Product { Name = "Батон", Price = 15.0d, Amount = 50, CategoryId = 3, Id = 5, CreatedDate = new DateTime(2026, 1, 31) },
            //    new Product { Name = "Кросівки", Price = 80.0d, Amount = 20, CategoryId = 4, Id = 6, CreatedDate = new DateTime(2026, 1, 31) }
            //    );
        }
    }
}
