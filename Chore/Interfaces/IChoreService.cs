using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChoreDataModel.Model;

namespace ChoreServiceBusHost.Interfaces
{
    public interface IChoreService
    {
        Task<Chore> AddCustomChoreAndDontAssign(int choreId, string choreName, bool assigned);
    }
}
