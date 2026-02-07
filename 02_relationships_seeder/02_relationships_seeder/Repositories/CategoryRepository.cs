using _02_relationships_seeder.data;
using _02_relationships_seeder.Entites;
using Microsoft.EntityFrameworkCore;

namespace _02_relationships_seeder.Repositories
{
    public class CategoryRepository
    {
        private readonly AppDbContext context;

        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }


        // CRUD операції
        // C - create
        // R - read
        // U - update
        // D - delete
        public async Task<IQueryable<Category>> GetAsync(int page = 1, int pageSize = 10)
        {
            int totalCount = await context.Categories.CountAsync();
            int pageCount = (int)Math.Ceiling((double)totalCount / pageSize);

            pageSize = pageSize <= 0 ? 10 : pageSize;
            page = page < 1 || page > pageCount ? 1 : page;

            return context.Categories
                .OrderBy(c => c.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await context.Categories
                .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        }

        public async Task<bool> CreateAsync(Category category)
        {
            try
            {
                await context.Categories.AddAsync(category);
                int res = await context.SaveChangesAsync(); // SaveChanges повертає скільки рядків було змінено у базі
                return res > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> CreateRangeAsync(IEnumerable<Category> categories)
        {
            try
            {
                await context.Categories.AddRangeAsync(categories);
                int res = await context.SaveChangesAsync(); // SaveChanges повертає скільки рядків було змінено у базі
                return res > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            try
            {
                context.Categories.Update(category);
                int res = await context.SaveChangesAsync(); // SaveChanges повертає скільки рядків було змінено у базі
                return res > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var category = await GetByIdAsync(id);
                context.Categories.Remove(category!);
                int res = await context.SaveChangesAsync(); // SaveChanges повертає скільки рядків було змінено у базі
                return res > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
