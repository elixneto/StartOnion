using System.Linq;

namespace StartOnion.Camada.Dominio
{
    public static class ExtensoesDeLinq
    {
        public static IQueryable<T> SkipAndTake<T>(this IQueryable<T> queryable, int page, int countPerPage) =>
            queryable.Skip((page - 1) * countPerPage).Take(countPerPage);
    }
}
