using api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace blogpost_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        [HttpPost]
        public string Post([FromBody] Blog value)
        {
            //save post to some repo
            string evbAPIUrl = "https://localhost:4005/api/PublishEvent";
            string reqObj = JsonConvert.SerializeObject(value);
            BlogAPIClient.BlogAPICient.PostApi(evbAPIUrl, reqObj);
            
            return "Success!";
        }
    }
}
