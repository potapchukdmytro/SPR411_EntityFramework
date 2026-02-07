using _02_relationships_seeder.data;
using _02_relationships_seeder.Entites;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace _02_relationships_seeder.Repositories
{
    public class ProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IQueryable<Product>> GetByAsync(Expression<Func<Product, bool>>? filter = null, int page = 1, int pageSize = 10, string sortProp = "id", bool isDescending = false)
        {
            int totalCount = await context.Products.CountAsync();
            int pageCount = (int)Math.Ceiling((double)totalCount / pageSize);

            pageSize = pageSize <= 0 ? 10 : pageSize;
            page = page < 1 || page > pageCount ? 1 : page;

            IQueryable<Product> result = context.Products;

            if(filter != null)
            {
                result = result.Where(filter);
            }

            return result
                .OrderByProperty(sortProp, isDescending)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

        }
    }
}
