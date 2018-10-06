using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace Food.Server.WebApi.Ping
{
   public class PingController : Controller
    {
        public string Get()
        {
            return "Food Server is up";
        }
    }
}
