using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace Food.Server.WebApi.Ping
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "Food Server is up";
        }
    }
}
