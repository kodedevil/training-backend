using MachDatum.Entitites;
using MachDatum.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MachDatum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository repository;

        public UsersController(UserRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            var users = repository.GetAll();
            return users;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = repository.GetById(id);
            return user;
        }

        [HttpPost]
        public object Post([FromBody] User user)
        {
            repository.Create(user);
            return user;
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
