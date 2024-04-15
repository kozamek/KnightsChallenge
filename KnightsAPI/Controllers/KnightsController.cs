using KnightsAPI.Entities;
using KnightsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KnightsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KnightsController : ControllerBase
    {
        private readonly IKnightsRepository _repository;

        public KnightsController(IKnightsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Knight>>> GetKnights()
        {
            var knights = await _repository.GetKnights();
            return Ok(knights);
        }

        [HttpGet("Heroes")]
        public async Task<ActionResult<IEnumerable<Knight>>> GetHeroes()
        {
            var heroes = await _repository.GetHeroes();
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Knight>>> GetKnight(string id)
        {
            var knigth = await _repository.GetKnight(id);

            if (knigth is null)
                return NotFound();

            return Ok(knigth);
        }

        [HttpPost]
        public async Task<IActionResult> CreateKnight([FromBody] Knight knight)
        {
            if (knight is null)
                return BadRequest("Invalid knight");

            await _repository.CreateKnight(knight);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKnight(string id, [FromBody] string newName)
        {
            if (newName is null)
                return BadRequest("Invalid knight");

            return Ok(await _repository.UpdateKnight(id, newName));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKnight(string id)
        {
            return Ok(await _repository.DeleteKnight(id));
        }
    }
}
