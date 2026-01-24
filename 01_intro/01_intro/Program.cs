using _01_intro.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace _01_intro
{
    internal class Program
    {
        static void ReadTable(AppDbContext context)
        {
            // Виведення
            IQueryable<ProductEntity> products = context.Products
                .Where(p => p.Price >= 5000 && p.Price <= 10000)
                .OrderBy(p => p.Price);

            foreach (var product in products)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine(product);
                Console.WriteLine("---------------------------");
            }
        }

        static void AddNewData(AppDbContext context)
        {
            // (N'Портативна колонка SoundGo', N'Компактна Bluetooth-колонка з потужним звучанням', 2199, SYSDATETIME()),
            // (N'Термокружка SteelCup', N'Зберігає тепло напоїв до 6 годин', 899, SYSDATETIME());
            // Додавання нового рядку в таблицю
            ProductEntity newProduct = new ProductEntity
            {
                Title = "Портативна колонка SoundGo",
                Description = "Компактна Bluetooth-колонка з потужним звучанням",
                Price = 2199d,
                CreateDate = new DateTime(2026, 1, 23, 12, 0, 0)
            };

            context.Products.Add(newProduct);

            // Застосувати зміни та виконати запит на базу
            context.SaveChanges();



            // Додавання багатьох товарів
            var newProducts = new ProductEntity[]
            {
                new ProductEntity
                {
                    Title = "Бездротова миша QuickClick",
                    Description = "Ергономічна миша для роботи та навчання",
                    Price = 749
                },
                new ProductEntity
                {
                    Title = "Клавіатура SilentType",
                    Description = "Тиха мембранна клавіатура з українською розкладкою",
                    Price = 1199
                },
                new ProductEntity
                {
                    Title = "Монітор ViewMax 24\"",
                    Description = "IPS монітор з Full HD роздільною здатністю",
                    Price = 6999
                },
                new ProductEntity
                {
                    Title = "USB-флешка DataStore 64GB",
                    Description = "Надійний накопичувач для зберігання файлів",
                    Price = 499
                },
                new ProductEntity
                {
                    Title = "Килимок для миші ControlPad",
                    Description = "Нековзка поверхня для точного керування",
                    Price = 299
                }
            };

            context.Products.AddRange(newProducts);
            context.SaveChanges();
        }

        static void DeleteData(AppDbContext context)
        {
            // Видалення
            var deleteProducts = context.Products.Where(p => p.Id == 51 || p.Id == 55);
            var deleteProduct = context.Products.FirstOrDefault(p => p.Id == 52);

            if (deleteProduct != null)
            {
                context.Products.Remove(deleteProduct);
            }
            context.Products.RemoveRange(deleteProducts);
            context.SaveChanges();
        }

        static void UpdateData(AppDbContext context)
        {
            // Редагування

            // Гірший спосіб коли ми створюємо новий товар і вказуємо id товару який хочемо змінити
            //var updatedProduct = new ProductEntity
            //{
            //    Id = 54,
            //    Title = "Монітор ViewMax 27\"",
            //    Description = "IPS монітор з Full HD роздільною здатністю",
            //    Price = 7999
            //};

            //context.Products.Update(updatedProduct);
            //context.SaveChanges();


            // Кращий спосіб через отримання товару з базу і подальшого його редагування
            var updatedProduct = context.Products.FirstOrDefault(p => p.Id == 22);

            if (updatedProduct != null)
            {
                updatedProduct.Title = "Гантелі 2x10 кг";
                updatedProduct.Price = 3499d;
                context.Products.Update(updatedProduct);
                context.SaveChanges();
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            using var context = new AppDbContext();

            //IQueryable<CategoryEntity> categories = context.Categories;
            //categories = categories.Take(5);

            //foreach (var category in categories)
            //{
            //    Console.WriteLine("---------------------------");
            //    Console.WriteLine(category);
            //    Console.WriteLine("---------------------------");
            //}

            // ReadTable(context);
            // AddNewData(context);
            // DeleteData(context);
        }
    }
}
