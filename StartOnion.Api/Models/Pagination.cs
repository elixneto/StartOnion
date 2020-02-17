namespace StartOnion.Api.Models
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Pagination
    {
        private uint _page = 1;
        private uint _countPerPage = 100;

        /// <summary>
        /// 
        /// </summary>
        public uint Page { get => _page; set { if (value <= 0) _page = 1; } }
        /// <summary>
        /// 
        /// </summary>
        public uint CountPerPage { get => _countPerPage; set { if (value > 100) _countPerPage = 100; } }
    }
}
