using System;
using System.Collections.Generic;
using System.Linq;
using Core.Contracts.Models;
using Core.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Diagnostics.Debug;

namespace Api.Controllers
{
    /// <summary>
    /// The WEB API controller that contains method to working on memory drives.
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DriveController : Controller
    {
        private readonly ISystemService _service;

        /// <summary>
        /// Creates a new instance of <see cref="DriveController"/>.
        /// </summary>
        public DriveController(ISystemService service)
        {
            Assert(service != null);
            _service = service;
        }

        /// <summary>
        /// Returns information about all drives in the computer.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<DriveInfo> Get()
        {
            Assert(_service != null);

            return _service.GetDrivesInfo();
        }

        /// <summary>
        /// Returns information about specified drive in computer.
        /// </summary>
        /// <param name="name">The drive name in the computer.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{name}")]
        public DriveInfo Get(String name)
        {
            Assert(_service != null);

            return _service
                   .GetDrivesInfo()
                   .FirstOrDefault(drive => drive.Name.ToUpper()
                                                 .Equals(name.ToUpper()));
        }
    }
}
