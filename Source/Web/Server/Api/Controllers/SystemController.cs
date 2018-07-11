using Core.Contracts.Models;
using Core.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Diagnostics.Debug;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SystemController : Controller
    {
        private readonly ISystemService _service;

        public SystemController(ISystemService service)
        {
            Assert(service != null);

            _service = service;
        }

        [HttpGet]
        public SystemInfo Get()
        {
            Assert(_service != null);

            return _service.GetSystemInfo();
        }
    }
}
