namespace Wicresoft.WFH.Data
{
    using System.Linq;

    public static class QueryableExtension
    {
        /// <summary>
        /// The paging.
        /// </summary>
        /// <param name="queryable">
        /// The queryable.
        /// </param>
        /// <param name="pageindex">
        /// The pageindex.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public static IQueryable<T> Paging<T>(this IQueryable<T> queryable, int pageindex, int pageSize)
        {
            return queryable.Skip((pageindex - 1) * pageSize).Take(pageSize);
        }
    }
}
