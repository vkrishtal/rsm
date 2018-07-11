using Core.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public sealed class NetController : Controller
    {
        private readonly ISystemService _service;

        public NetController(ISystemService service)
        {
            _service = service;
        }
    }
}
