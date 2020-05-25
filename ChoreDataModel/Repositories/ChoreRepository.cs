using ChoreDataModel.Context;
using ChoreDataModel.Interfaces;

namespace ChoreDataModel.Repositories
{
    public class ChoreRepository<T> : RepositoryBase<T, ChoreContext>, IChoreRepository<T> where T : class, IChoreEntity, new()
    {
        public ChoreRepository(ChoreContext context) : base(context)
        {
        }
    }
}
