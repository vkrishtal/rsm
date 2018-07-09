using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public sealed class RamController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<String> Get()
        {
            return new String[] { "Hello Vova!" };
        }
    }
}