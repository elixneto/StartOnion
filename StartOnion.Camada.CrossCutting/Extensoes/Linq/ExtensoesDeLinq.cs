using System.Linq;

namespace StartOnion.Camada.CrossCutting.Extensoes.Linq
{
    /// <summary>
    /// Extensões para System.Linq
    /// </summary>
    public static class ExtensoesDeLinq
    {
        /// <summary>
        /// Faz a paginação de uma query
        /// </summary>
        /// <typeparam name="T">Modelo/Entidade</typeparam>
        /// <param name="queryable">Query</param>
        /// <param name="page">Número da página</param>
        /// <param name="countPerPage">Quantidade de registros por página</param>
        /// <returns></returns>
        public static IQueryable<T> SkipAndTake<T>(this IQueryable<T> queryable, int page, int countPerPage) =>
            queryable.Skip((page - 1) * countPerPage).Take(countPerPage);
    }
}
