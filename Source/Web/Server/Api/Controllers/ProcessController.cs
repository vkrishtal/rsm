using System.Collections.Generic;
using Core.Contracts.Models;
using Core.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public sealed class ProcessController : Controller
    {
        private readonly ISystemService _service;

        public ProcessController(ISystemService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<ProcessInfo> Get()
        {
            return _service.GetProcesses();
        }
    }
}
