﻿using Core.Contracts.Models;
using Core.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Diagnostics.Debug;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public sealed class RamController : Controller
    {
        private readonly ISystemService _service;

        public RamController(ISystemService service)
        {
            Assert(service != null);

            _service = service;
        }

        // GET api/values
        [HttpGet]
        public RamInfo Get()
        {
            Assert(_service != null);

            return _service.GetRamInfo();
        }
    }
}
