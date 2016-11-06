using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Food.Server.WebApi.Ping
{
   public class PingController : ApiController
    {
        public  string Get()
        {
            return "Food Server is up";
        }
    }
}
