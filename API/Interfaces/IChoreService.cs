using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChoreDataModel.Model;

namespace API.Interfaces
{
    public interface IChoreService
    {
        Task<List<Chore>> Get();
        Task CreateChore(Chore chore);
        Task<Chore> UpdateChore(Chore chore);
        Task<bool> DeleteChore(int id);

    }
}
