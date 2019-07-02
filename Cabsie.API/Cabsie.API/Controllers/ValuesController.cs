using System.Collections.Generic;
using System.Linq;
using Cabsie.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cabsie.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var data = Enumerable.Range(0, 5).Select(i =>
                new UserVM()
                {
                    FirstName = $"First_{i:N2}",
                    LastName = $"Last_{i:N2}",
                    MiddleName = $"Mid_{i:N2}"
                }
            );
            return Ok(data);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
