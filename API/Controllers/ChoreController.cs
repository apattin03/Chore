using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChoreDataModel.Interfaces;
using ChoreDataModel.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ChoreController : ControllerBase
    {

        private readonly IChoreRepository<Chore> _choreRepository;

        public ChoreController(IChoreRepository<Chore> choreRepository)
        {

            _choreRepository = choreRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Chore>>> Get()
        {
            return await _choreRepository.ToListAsync();
        }

        [HttpPost]
        public async Task Post(Chore chore)
        {
            _choreRepository.Add(chore);
            await _choreRepository.SaveChangesAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, Chore chore)
        {
            var exists = _choreRepository.Where(c => c.ChoreID == chore.ChoreID);

            if (exists == null)
                return NotFound();

            _choreRepository.Update(chore);
            await _choreRepository.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _choreRepository.FirstOrDefaultAsync(c => c.ChoreID == id);

            _choreRepository.Delete(entity);
            await _choreRepository.SaveChangesAsync();
            return Ok("success");
        }
    }
}