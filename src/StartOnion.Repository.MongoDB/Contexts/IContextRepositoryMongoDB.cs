using System;
using System.Threading.Tasks;

namespace StartOnion.Repository.MongoDB.Contexts
{
    public interface IContextRepositoryMongoDB
    {
        void Commit();
        void Rollback();
    }
}
