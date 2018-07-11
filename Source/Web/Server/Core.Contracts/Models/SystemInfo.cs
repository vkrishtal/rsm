using System;

namespace Core.Contracts.Models
{
    /// <summary>
    /// Represents DTO for storing information about system.
    /// </summary>
    public sealed class SystemInfo
    {
        /// <summary>
        /// The OS architecture type.
        /// </summary>
        public String OsArchitecture { get; }

        /// <summary>
        /// The OS description (name, version etc).
        /// </summary>
        public String OsDescription { get; }

        /// <summary>
        /// The CPU architecture type.
        /// </summary>
        public String CpuArchitecture { get; }

        /// <summary>Initializes a new instance of the <see cref="SystemInfo"></see> class.</summary>
        public SystemInfo(String osArchitecture, String osDescription, String cpuArchitecture)
        {
            OsArchitecture = osArchitecture;
            OsDescription = osDescription;
            CpuArchitecture = cpuArchitecture;
        }
    }
}
