using MachDatum.Entitites;
using MachDatum.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MachDatum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly TeamsRepository repository;

        public TeamsController(TeamsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Team> Get()
        {
            var teams = repository.GetAll();
            return teams;
        }

        [HttpGet("{id}")]
        public Team Get(int id)
        {
            var team = repository.GetById(id);
            return team;
        }

        [HttpPost]
        public object Post([FromBody] Team team)
        {
            repository.Create(team);
            return team;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Delete(repository.GetById(id));
        }
    }
}
