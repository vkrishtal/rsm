using System.Collections.Generic;
using Core.Contracts.Models;

namespace Core.Contracts.Services
{
    public interface ISystemService
    {
        SystemInfo GetSystemInfo();
        RamInfo GetRamInfo();
        IReadOnlyList<DriveInfo> GetDrivesInfo();
        IReadOnlyList<ProcessInfo> GetProcesses();
        NetworkInfo GetNetworkInfo();
    }
}
