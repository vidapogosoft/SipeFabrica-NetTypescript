using BackendTaller.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BackendTaller.Models.DTO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendTaller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        private IJwt _auth;

        public TokenController(IJwt auth)
        {
            _auth = auth;
        }


        // POST api/<TokenController>
        [HttpPost("auth")]
        public IActionResult Post([FromBody] DTOUser user)
        {
            var token = _auth.auth(user.username, user.password);

            if (token == string.Empty)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        // GET: api/<TokenController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TokenController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<TokenController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<TokenController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
