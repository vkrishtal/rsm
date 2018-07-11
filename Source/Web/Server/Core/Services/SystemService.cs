using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using Core.Contracts.Models;
using Core.Contracts.Services;
using Core.Extensions;
using static System.Diagnostics.Debug;
using static System.IO.DriveInfo;

namespace Core.Services
{
    /// <summary>
    /// The service to working on the system details like a RAM or drives etc.
    /// </summary>
    public sealed class SystemService : ISystemService
    {
        /// <summary>
        /// Returns information about RAM.
        /// </summary>
        /// <returns></returns>
        public RamInfo GetRamInfo()
        {
            var used = Process
                       .GetProcesses()
                       .Select(process => process.WorkingSet64)
                       .Sum();


            return new RamInfo(0, used);
        }

        /// <summary>
        /// Returns information about system.
        /// </summary>
        /// <returns></returns>
        public SystemInfo GetSystemInfo() => new SystemInfo(
            RuntimeInformation.OSArchitecture.ToString(),
            RuntimeInformation.OSDescription,
            RuntimeInformation.ProcessArchitecture.ToString());

        /// <summary>
        /// Returns information about computer drives.
        /// </summary>
        public IReadOnlyList<DriveInfo> GetDrivesInfo() =>
            GetDrives()
                .WhereFixed()
                .Select(Cast)
                .ToList()
                .AsReadOnly();

        /// <summary>
        /// Converts System.IO.DriveInfo to Models.DriveInfo.
        /// </summary>
        /// <param name="drive">The source drive info.</param>
        /// <returns>The Core.Models DTO.</returns>
        private DriveInfo Cast(System.IO.DriveInfo drive)
        {
            Assert(drive != null);

            return new DriveInfo(drive.Name, drive.VolumeLabel,
                drive.AvailableFreeSpace, drive.TotalSize);
        }
    }
}
