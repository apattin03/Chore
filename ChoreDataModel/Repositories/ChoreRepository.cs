using System;
using System.Collections.Generic;
using System.Text;
using ChoreDataModel.Context;
using ChoreDataModel.Interfaces;
using ChoreDataModel.Model;

namespace ChoreDataModel.Repositories
{
    public class ChoreRepository<T> : RepositoryBase<T, ChoreContext>, IChoreRepository<T> where T: class, IChoreEntity, new()
    {
        public ChoreRepository(ChoreContext context) : base(context)
        {
        }
    }
}
