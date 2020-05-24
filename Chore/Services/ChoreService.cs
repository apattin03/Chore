using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChoreDataModel.Interfaces;
using ChoreDataModel.Model;
using ChoreServiceBusHost.Interfaces;

namespace ChoreServiceBusHost.Services
{
    public class ChoreService : IChoreService
    {
        //private readonly IChoreRepository<Chore> _choreRepository;
        //private readonly IChoreRepository<Partner> _partnerRepository;
        //private readonly IChoreRepository<ChoreSprint> _choreSprintRepository;

        //public ChoreService(IChoreRepository<Chore> choreRepository)
        //{
        //    _choreRepository = choreRepository;
        //}

        public async Task<Chore> AddCustomChoreAndDontAssign(int choreId, string choreName, bool assigned)
        {
            var chore = new Chore()
            {
                ChoreName = choreName,
                ChoreID = choreId,
                Assigned = assigned
            };
            //_choreRepository.Add(chore);
            //await _choreRepository.SaveChangesAsync();
            return chore;
        }

    
    }
}
