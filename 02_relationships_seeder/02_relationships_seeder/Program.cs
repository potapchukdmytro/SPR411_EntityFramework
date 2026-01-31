using _02_relationships_seeder.data;
using _02_relationships_seeder.entites;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text;

public class Program
{
    static List<Product> GetProdcutsByUser(User user)
    {
        var items = user.Orders
            .SelectMany(o => o.OrderItems)
            .Select(oi => oi.Product)
            .Distinct()
            .ToList();

        return items;
    }

    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        var dbContext = new AppDbContext();
        Seeder.Seed(dbContext);

        // створення категорій то товарів для них

        //var milkProducts = new Category { Name = "Молочні вироби" };

        //dbContext.Categories.Add(milkProducts);
        //dbContext.SaveChanges();

        //var milk = new Product { Name = "Молоко", Amount = 23, Price = 55.0d, CategoryId = 1 };
        //dbContext.Products.Add(milk);
        //dbContext.SaveChanges();


        //var phones = new Category { Name = "Мобільні телефони" };
        //dbContext.Categories.Add(phones);

        //var iphone15 = new Product { Name = "Iphone 15", Amount = 5, Price = 30000.0d, Category = phones};
        //dbContext.Products.Add(iphone15);

        //dbContext.SaveChanges();



        // додавання товарів до вже існуюючої категорії
        //var milk = dbContext.Categories.FirstOrDefault(c => c.Name == "Молочні вироби");

        //if (milk != null)
        //{
        //    var milkProducts = new List<Product>
        //    {
        //        new Product {Name = "Сир", Price = 33.0d, Amount = 65, Category = milk},
        //        new Product {Name = "Йогурт", Price = 25.0d, Amount = 15, CategoryId = milk.Id},
        //        new Product {Name = "Сметана", Price = 60.0d, Amount = 5, CategoryId = milk.Id}
        //    };

        //    dbContext.Products.AddRange(milkProducts);
        //    dbContext.SaveChanges();
        //}



        // додавання товарів до вже існуюючої категорії
        //var phonesCategory = dbContext.Categories.FirstOrDefault(c => c.Name == "Мобільні телефони");

        //if(phonesCategory != null)
        //{
        //    var phones = new List<Product>
        //    {
        //        new Product {Name = "Samsung galaxt s24", Price = 25.0d, Amount = 3},
        //        new Product {Name = "Redmi 14", Price = 15.0d, Amount = 10}
        //    };

        //    phonesCategory.Products.AddRange(phones);
        //    dbContext.SaveChanges();

        //}


        // Roles
        var adminRole = new Role { Name = "admin" };
        var userRole = new Role { Name = "user" };


        // Users
        //var admin = new User { Email = "admin@mail.com", FirstName = "John", LastName = "Smith" };
        //var user = new User { Email = "user@mail.com", FirstName = "Mike", LastName = "Thomson" };

        //user.Roles.Add(userRole);
        //dbContext.Users.Add(user);

        //adminRole.Users.Add(admin);
        //dbContext.Roles.Add(adminRole);

        //dbContext.SaveChanges();



        //var user = dbContext.Users.FirstOrDefault(u => u.Email == "user@mail.com");
        //var iphone15 = dbContext.Products.FirstOrDefault(p => p.Name == "Iphone 15");
        //var sourCream = dbContext.Products.FirstOrDefault(p => p.Name == "Сметана");

        //if (user != null && iphone15 != null && sourCream != null)
        //{
        //    var order = new Order
        //    {
        //        UserId = user.Id
        //    };

        //    var orderItem = new OrderItem
        //    {
        //        Quantity = 1,
        //        Product = iphone15,
        //        Order = order
        //    };

        //    dbContext.OrderItems.Add(orderItem);
        //    dbContext.SaveChanges();


        //    var sourCreamItem = new OrderItem
        //    {
        //        Product = sourCream,
        //        Quantity = 4,
        //        Order = new Order
        //        {
        //            User = user
        //        }
        //    };

        //    dbContext.OrderItems.Add(sourCreamItem);
        //    dbContext.SaveChanges();
        //}





        // читання даних
        //var milkCategory = dbContext.Categories
        //    .Include(c => c.Products)  // include підвантажує пов'язані дані з іншої таблиці
        //    .FirstOrDefault(c => c.Name == "Молочні вироби");

        //if (milkCategory == null)
        //{
        //    return;
        //}

        //Console.WriteLine("Категорія - " + milkCategory);
        //foreach (var product in milkCategory.Products)
        //{
        //    Console.WriteLine(product);
        //}



        //var phone = dbContext.Products
        //    .Include(p => p.Category)
        //    .FirstOrDefault(p => p.Name == "Samsung galaxt s24");

        //if(phone != null && phone.Category != null)
        //{
        //    Console.WriteLine(phone.Category.Name);
        //}


        //var phones = dbContext.Products
        //    .Include(p => p.Category)
        //    .Where(p => p.Category!.Name == "Мобільні телефони")
        //    .ToList();



        //var user = dbContext.Users
        //    .Include(u => u.Orders)
        //    .ThenInclude(o => o.OrderItems)
        //    .ThenInclude(oi => oi.Product)
        //    .FirstOrDefault(u => u.Email == "user@mail.com");

        //var products = GetProdcutsByUser(user!);

        //foreach (var item in products)
        //{
        //    Console.WriteLine(item);
        //}
    }
}