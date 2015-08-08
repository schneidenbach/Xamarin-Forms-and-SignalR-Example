using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace XamarinSignalRExample.Server.Controllers
{
    [Authorize]
    public class TestController : ApiController
    {
        public string Get()
        {
            return "You got here!";
        }
    }
}
