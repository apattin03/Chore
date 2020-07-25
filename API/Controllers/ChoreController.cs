using System.Collections.Generic;
using System.Threading.Tasks;
using API.Interfaces;
using ChoreDataModel.Interfaces;
using ChoreDataModel.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ChoreController : ControllerBase
    {

        private readonly IChoreService _choreService;

        public ChoreController(IChoreService choreService)
        {
            _choreService = choreService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Chore>>> Get()
        {
            return await _choreService.Get();
        }

        [HttpPost]
        public async Task Post(Chore chore)
        {
            await _choreService.CreateChore(chore);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Chore chore)
        {
            await _choreService.UpdateChore(chore);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedChore = await _choreService.DeleteChore(id);
            if (deletedChore)
            {
                return Ok("success");
            }
            return NotFound();
        }
    }
}