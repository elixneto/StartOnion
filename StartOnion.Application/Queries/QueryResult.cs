using StartOnion.Application.VMs;
using System.Collections.Generic;

namespace StartOnion.Application.Queries
{
    public class QueryResult<T> where T: VM
    {
        public int TotalCount { get; }
        public IEnumerable<T> Records { get; }

        public QueryResult(int total, IEnumerable<T> records)
        {
            TotalCount = total;
            Records = records;
        }
    }
}
