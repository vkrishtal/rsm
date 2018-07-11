using System;

namespace Core.Contracts.Models
{
    /// <summary>
    /// Represents DTO for storing information about drives.
    /// </summary>
    public sealed class DriveInfo
    {
        /// <summary>
        /// The drive name.
        /// </summary>
        public String Name { get; }

        /// <summary>
        /// The drive value label.
        /// </summary>
        public String Label { get; }

        /// <summary>
        /// The drive free space.
        /// </summary>
        public Int64 AvailableFreeSpace { get; }

        /// <summary>
        /// The drive total space.
        /// </summary>
        public Int64 TotalSpace { get; }

        /// <summary>
        /// The drive used space.
        /// </summary>
        public Int64 UsedSpace => TotalSpace - AvailableFreeSpace;

        /// <summary>Initializes a new instance of the <see cref="DriveInfo"></see> class.</summary>
        public DriveInfo(String name, String label, Int64 availableFreeSpace, Int64 totalSpace)
        {
            Name = name;
            Label = label;
            AvailableFreeSpace = availableFreeSpace;
            TotalSpace = totalSpace;
        }
    }
}
