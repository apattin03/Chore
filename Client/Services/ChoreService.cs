using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChoreDataModel.Interfaces;
using ChoreDataModel.Model;
using Chores.Interfaces;

namespace Chores.Services
{
    public class ChoreService : IChoreService
    {
        private readonly IChoreRepository<Chore> _choreRepository;
        private readonly IChoreRepository<Partner> _partnerRepository;
        private readonly IChoreRepository<ChoreSprint> _choreSprintRepository;

        public ChoreService(IChoreRepository<Chore> choreRepository)
        {
            _choreRepository = choreRepository;
        }


        public async Task<List<Chore>> GetAllChores()
        {
          var chores = await _choreRepository.ToListAsync();
          return chores;
        }

        public void AddChore(Chore chore)
        {
            _choreRepository.Add(chore);
        }

        public async Task<Chore> UpdateChore(Chore chore)
        {
           _choreRepository.Update(chore);

           return chore;
        }

        public void DeleteChore(Chore chore)
        {
            _choreRepository.Delete(chore);
        }

        public async Task<int> SaveChangesAsync()
        {
           return await _choreRepository.SaveChangesAsync();
        }
    }
}
