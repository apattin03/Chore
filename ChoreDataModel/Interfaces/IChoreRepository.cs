using System;
using System.Collections.Generic;
using System.Text;
using ChoreDataModel.Context;

namespace ChoreDataModel.Interfaces
{
    public interface IChoreRepository<T> : IRepository<T, ChoreContext> where T : class, IChoreEntity, new()
    {
    }
}
