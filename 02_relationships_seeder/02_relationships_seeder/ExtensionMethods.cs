using System.Linq.Expressions;

namespace _02_relationships_seeder
{
    public static class ExtensionMethods
    {
        public static IQueryable<T> OrderByProperty<T>(this IQueryable<T> source, string propertyName, bool isDescending = false)
        {
            if(string.IsNullOrEmpty(propertyName.Trim()))
            {
                return source;
            }

            var param = Expression.Parameter(typeof(T), "x");

            Expression body = param;
            foreach (var m in propertyName.Split("."))
            {
                body = Expression.PropertyOrField(body, m);
            }

            var lamda = Expression.Lambda(body, param);

            var methodName = isDescending ? "OrderByDescending" : "OrderBy";
            var result = Expression.Call(typeof(Queryable), methodName, [typeof(T), body.Type], source.Expression, Expression.Quote(lamda));

            return source.Provider.CreateQuery<T>(result);
        }
    }
}
