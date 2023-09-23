using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMVC.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeopleDTO>>> Get()
        {
            var peoples = await _peopleService.GetPeoples();

            if (peoples == null)
            {
                return NotFound("Pessoa não encontrada!");
            }

            return Ok(peoples);
        }

        [HttpGet("{id:int}", Name = "GetPeople")]
        public async Task<ActionResult<PeopleDTO>> GetById(int id)
        {
            var people = await _peopleService.GetById(id);

            if (people == null)
            {
                return NotFound("Pessoa não encontrada!");
            }

            return Ok(people);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PeopleDTO people)
        {
            if (people == null)
                return BadRequest("Dados Inválidos");

            await _peopleService.Add(people);

            return new CreatedAtRouteResult("GetPeople", new { id = people.Id}, people);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] PeopleDTO people)
        {
            if (id != people.Id)
                return BadRequest("Dados Inválidos");

            if (people == null)
                return BadRequest("Dados Inválidos");

            await _peopleService.Update(people);

            return Ok(people);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PeopleDTO>> Delete(int id)
        {
            var people = await _peopleService.GetById(id);

            if (people == null)
                return NotFound("Pessoa não encontrada!");

            await _peopleService.Remove(id);

            return Ok(people);
        }
    }
}