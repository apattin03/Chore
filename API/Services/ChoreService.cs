using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using ChoreDataModel.Interfaces;
using ChoreDataModel.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public class ChoreService : IChoreService
    {
        private readonly IChoreRepository<Chore> _choreRepository;

        public ChoreService(IChoreRepository<Chore> choreRepository)
        {
            _choreRepository = choreRepository;
        }

        public async Task<List<Chore>> Get()
        {
            return await _choreRepository.ToListAsync();
        }

        public async Task CreateChore(Chore chore)
        {
            _choreRepository.Add(chore);
            await _choreRepository.SaveChangesAsync();
        }

        public async Task<Chore> UpdateChore(Chore chore)
        {
            var exists = _choreRepository.Where(c => c.ChoreID == chore.ChoreID);

            //want to throw exception here?

            _choreRepository.Update(chore);
            await _choreRepository.SaveChangesAsync();
            return chore;
        }

        public async Task<bool> DeleteChore(int id)
        {
            var entity = await _choreRepository.FirstOrDefaultAsync(c => c.ChoreID == id);
            _choreRepository.Delete(entity);
            await _choreRepository.SaveChangesAsync();

            return true;
        }
    }
}
