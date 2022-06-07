using api.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace queryms_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryServiceController : ControllerBase
    {
        // GET: api/<QueryServiceController>
        [HttpGet]
        public List<Blog> Get()
        {
            string evntAPIUrl = "http://localhost:3005/api/PublishEvent";
            var responseStr = BlogAPIClient.BlogAPICient.GetApi(evntAPIUrl);

            var reponse = JsonConvert.DeserializeObject<List<Blog>>(responseStr);
            return reponse;
        }

        // GET api/<QueryServiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<QueryServiceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<QueryServiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QueryServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
