using System.Web.Http;

namespace Food.Server.WebApi.Ping
{
   public class PingController : ApiController
    {
        public string Get()
        {
            return "Food Server is up";
        }
    }
}
