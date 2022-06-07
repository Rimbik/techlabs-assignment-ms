using api.Model;
using eventbus_api.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eventbus_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishEventController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public List<Blog> Get()
        {
            return EventStore.GetAllEvents();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public List<Blog> Get(int id)
        {
            return EventStore.GetAllEvents();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public string Post([FromBody] Blog post)
        {
            EventStore.SaveEvent(post.BlogID, post.BlogMessage);
            return "Post Success";
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public bool Put([FromBody] Blog post)
        {
            EventStore.SaveComment(post.BlogID, post.Comments.First());

            return true;
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
