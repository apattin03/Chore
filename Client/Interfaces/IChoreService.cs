using System.Threading.Tasks;


namespace Chores.Interfaces
{
    public interface IChoreService
    {
        Task<ChoreDataModel.Model.Chore> AddCustomChoreAndDontAssign(int choreId, string choreName, bool assigned);
    }
}
