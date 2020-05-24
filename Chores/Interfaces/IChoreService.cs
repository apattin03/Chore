using System.Collections.Generic;
using System.Threading.Tasks;
using ChoreDataModel.Model;


namespace Chores.Interfaces
{
    public interface IChoreService
    {
        Task<List<Chore>> GetAllChores();
        void AddChore(Chore chore);
        Task<Chore> UpdateChore(Chore chore);
        void DeleteChore(Chore chore);
        Task<int> SaveChangesAsync();

    }
}
