using System;

namespace Core.Contracts.Models
{
    /// <summary>
    /// Represents DTO for storing information about RAM.
    /// </summary>
    public sealed class RamInfo
    {
        /// <summary>
        /// The free memory space (in bytes).
        /// </summary>
        public Int64 Free { get; }
        
        /// <summary>
        /// The used memory space (in bytes).
        /// </summary>
        public Int64 Used { get; }

        /// <summary>
        /// The total RAM size.
        /// </summary>
        public Int64 Total => Used + Free;

        /// <summary>Initializes a new instance of the <see cref="RamInfo"></see> class.</summary>
        public RamInfo(Int64 free, Int64 used)
        {
            Free = free;
            Used = used;
        }
    }
}
