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
        private readonly IConfiguration Configuration;
        public BlogPostController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost]
        public string Post([FromBody] Blog value)
        {
            var downStreamAppUrl = Configuration["WebAPIEnv:eventbus_apiUrl"];

            //save post to some repo
            string evbAPIUrl = downStreamAppUrl;
            string reqObj = JsonConvert.SerializeObject(value);
           
            var respnse = BlogAPIClient.BlogAPICient.PostApi(evbAPIUrl, reqObj);
            
            return respnse;
        }
    }
}
