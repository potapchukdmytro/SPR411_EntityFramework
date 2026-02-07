using _02_relationships_seeder.data;
using _02_relationships_seeder.Entites;
using _02_relationships_seeder.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.IO;
using System.Net.WebSockets;
using System.Reflection.Metadata;
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

    private static void RelationshipsLesson()
    {
        //Seeder.Seed(dbContext);

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

    private static void Tracking(AppDbContext dbContext)
    {
        // Tracking
        //var categories = dbContext.Categories.ToList();

        //var products = dbContext.Products.AsNoTracking().ToList();


        //var product = dbContext.Products.FirstOrDefault(p => p.Id == 10);

        // EntityState.Detached - dbcontext перестає слідкувати за об'єктом
        //dbContext.Entry<Product>(product).State = EntityState.Detached;

        //if (product != null)
        //{
        //    product.Amount = 85;
        //    dbContext.SaveChanges();
        //}


        //var newProduct = new Product
        //{
        //    Id = 10,
        //    Name = "Пляшка спортивна",
        //    Amount = 50,
        //    CategoryId = 6,
        //    CreatedDate = DateTime.UtcNow,
        //    Description = "Пляшка для води 750 мл",
        //    Price = 349.0d
        //};

        //dbContext.Products.Update(newProduct);
        //dbContext.SaveChanges();



        //Category? toys = dbContext.Categories.FirstOrDefault(c => c.Id == 7);

        //toys!.Products.Add(new Product
        //{
        //    Name = "Кубик рубика",
        //    Amount = 26,
        //    CreatedDate = DateTime.UtcNow,
        //    Price = 35.0d,
        //    Description = "Кубик рубика 3х3 з пластику"
        //});

        //dbContext.SaveChanges();



        // Коли dbcontext кидає запит в базу

        // 1. SaveChanges()
        // 2. Коли витягуємо дані не у типі IQueryable

        IQueryable<Product> products = dbContext.Products;

        products = products.Where(p => p.Price > 100.0d);
        // dbContext.Products.ToList(); // ToList викличе запит у базу даних

        foreach (var item in products) // SELECT * FROM Products WHERE price >= 100
        {

        }
    }

    private static void DataLoading()
    {
        // Завантаження даних
        // eager - жадібне
        // Include

        //var category = dbContext.Categories
        //    .Include(c => c.Products) // підтягне дані про товари разом із категорієї
        //    .ThenInclude(p => p.OrderItems)
        //    .ThenInclude(oi => oi.Order)
        //    .First();

        //var product = dbContext.Products.FirstOrDefault(p => p.Category.Name == category.Name);




        // Explicit - явне
        //var category = dbContext.Categories.First();

        //Console.WriteLine(category);


        //dbContext.Entry(category)        // Collection().Load() - явне завантаження колекції
        //    .Collection(c => c.Products)
        //    .Load();

        //var oi = dbContext.OrderItems.First();

        //dbContext.Entry(oi).Reference(oi => oi.Order).Load(); // Reference().Load() - явне завантаження об'єкта




        // Lazy - ліниве
        // Потрібно встановити пакет Microsoft.EntityFrameworkCore.Proxies
        // Також прописати налаштування в AppDbContext
        // Navgation Property необхідно зробити virtual

        // var category = dbContext.Categories.First();

        //var order = dbContext.Orders.First();

        //Console.WriteLine(order.User.FirstName);

        //foreach (var p in category.Products)
        //{

        //}
    }

    private static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        var dbContext = new AppDbContext();
        var categoryRepository = new CategoryRepository(dbContext);
        var productRepository = new ProductRepository(dbContext);

        var categories = await categoryRepository.GetAsync(9);
        //bool res = await categoryRepository.CreateAsync(new Category { Name = "Товари для творчості" });

        foreach (var c in categories)
        {
            //Console.WriteLine(c);
        }
        
        var category = await categoryRepository.GetByNameAsync("Сад і город");
        //Console.WriteLine(category);


        var products = await productRepository.GetByAsync(filter: p => p.Amount < 50, page: 2, pageSize: 10, sortProp: "price", isDescending: true);
        foreach (var item in products)
        {
            Console.WriteLine(item);
        }
    }
}