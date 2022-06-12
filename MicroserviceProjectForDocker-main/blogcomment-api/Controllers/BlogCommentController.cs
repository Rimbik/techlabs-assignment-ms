using api.Model;
using blogcomment_api.ConfigHelper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace blogcomment_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCommentController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        public BlogCommentController(IConfiguration configRoot)
        {
            Configuration = configRoot;
        }


        // POST api/<ValuesController>
        [HttpPost]
        public bool Post([FromBody] Blog comment)
        {
            var downStreamAppUrl= Configuration["WebAPIEnv:eventbus_apiUrl"];

            //save post to some repo
            string evbAPIUrl = downStreamAppUrl;
            string reqObj = JsonConvert.SerializeObject(comment);
            BlogAPIClient.BlogAPICient.PostApi(evbAPIUrl, reqObj);

            return true;
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public bool Put([FromBody] Blog post)
        {
            //save post to some repo
            string evbAPIUrl = "http://localhost:3005/api/PublishEvent";
            string reqObj = JsonConvert.SerializeObject(post);

            BlogAPIClient.BlogAPICient.PutApi(evbAPIUrl, reqObj);

            return true;
        }

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
