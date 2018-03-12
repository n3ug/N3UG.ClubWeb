using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clubweb.shared.interfaces;
using clubweb.shared.models.user;
using Microsoft.AspNetCore.Mvc;

namespace clubweb.server.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public IUserRepository _repo { get; }

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var results = new List<userViewModel>();
            var users = _repo.GetUsers(null);
            foreach (var user in users)
            {
                results.Add(new userViewModel(user));
            }
            return Ok(results);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var o = _repo.GetUserById(id);
            if (o == null)
            {
                return NotFound($"User {id} Not Found");
            }

            var vm = new userViewModel(o);
            
            return Ok(vm);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
