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
            string evbAPIUrl = "http://localhost:3005/api/PublishEvent";
            string reqObj = JsonConvert.SerializeObject(value);
           var respnse = BlogAPIClient.BlogAPICient.PostApi(evbAPIUrl, reqObj);
            
            return respnse;
        }
    }
}
