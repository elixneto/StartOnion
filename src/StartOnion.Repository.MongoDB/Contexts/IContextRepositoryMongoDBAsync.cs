using System;
using System.Threading.Tasks;

namespace StartOnion.Repository.MongoDB.Contexts
{
    public interface IContextRepositoryMongoDBAsync
    {
        Task AddCommand(Func<Task> command);
        Task Commit();
        void Rollback();
    }
}
