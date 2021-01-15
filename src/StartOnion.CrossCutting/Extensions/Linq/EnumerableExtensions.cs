using System.Collections.Generic;
using System.Linq;

namespace StartOnion.CrossCutting.Extensions.Linq
{
    /// <summary>
    /// Extensions for IEnumerable with System.Linq
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// ToList().AsReadOnly()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IReadOnlyCollection<T> AsCollectionReadOnly<T>(this IEnumerable<T> enumerable) => enumerable.ToList().AsReadOnly();

        /// <summary>
        /// ToList().AsReadOnly()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IReadOnlyList<T> AsListReadOnly<T>(this IEnumerable<T> enumerable) => enumerable.ToList().AsReadOnly();
    }
}
