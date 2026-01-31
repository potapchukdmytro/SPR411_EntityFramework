using _02_relationships_seeder.entites;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace _02_relationships_seeder.data
{
    public static class Seeder
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.Migrate();

            SeedUsersAndRoles(context);
            SeedProductAndCategories(context);
        }

        private static void SeedUsersAndRoles(AppDbContext context)
        {
            if (!context.Roles.Any() && !context.Users.Any())
            {
                var adminRole = new Role { Name = "admin" };
                var userRole = new Role { Name = "user" };
                var managerRole = new Role { Name = "manager" };

                var admin = new User { Email = "admin@mail.com", FirstName = "John", LastName = "Smith" };
                var user = new User { Email = "user@mail.com", FirstName = "Mike", LastName = "Thomsom" };
                var manager = new User { Email = "manager@mail.com", FirstName = "Ema", LastName = "Stuart" };

                admin.Roles.Add(adminRole);
                admin.Roles.Add(userRole);

                user.Roles.Add(userRole);

                manager.Roles.Add(managerRole);
                manager.Roles.Add(userRole);

                context.Users.AddRangeAsync(admin, user, manager);
                context.SaveChangesAsync();
            }
        }

        private static void SeedProductAndCategories(AppDbContext context)
        {
            var dataPath = @"C:\itstep\3 семестр\SP411\EF\SPR411_EntityFramework\02_relationships_seeder\02_relationships_seeder\data\seedData";
            var categoriesPath = Path.Combine(dataPath, "categories.json");
            var productsPage = Path.Combine(dataPath, "products");

            var categoriesJson = File.ReadAllText(categoriesPath);
            var categories = JsonSerializer.Deserialize<List<Category>>(categoriesJson);

            if (categories == null)
            {
                return;
            }

            foreach (var item in categories)
            {
                var category = item;

                if(!context.Categories.Any(c => c.Name == category.Name))
                {
                    context.Categories.Add(category);
                }
                else
                {
                    category = context.Categories
                        .Include(c => c.Products)
                        .FirstOrDefault(c => c.Name == item.Name)!;
                }

                if(!category.Products.Any())
                {
                    var path = Path.Combine(productsPage, $"{category.Name}.json");

                    if (File.Exists(path))
                    {
                        var productsJson = File.ReadAllText(path);
                        var products = JsonSerializer.Deserialize<List<Product>>(productsJson);

                        if (products != null)
                        {
                            category.Products.AddRange(products);
                        }
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
