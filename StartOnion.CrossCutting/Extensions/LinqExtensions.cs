using System.Linq;

namespace StartOnion.CrossCutting.Extensions
{
    /// <summary>
    /// Extensions for System.Linq
    /// </summary>
    public static class LinqExtensions
    {
        /// <summary>
        /// Pagination for a queryable
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="queryable">Query</param>
        /// <param name="page">Current page</param>
        /// <param name="countPerPage">Count records per page</param>
        /// <returns></returns>
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, int page, int countPerPage) =>
            queryable.Skip((page - 1) * countPerPage).Take(countPerPage);

        /// <summary>
        /// Skip then take
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static IQueryable<T> SkipAndTake<T>(this IQueryable<T> queryable, int skip, int take) =>
            queryable.Skip(skip).Take(take);
    }
}
