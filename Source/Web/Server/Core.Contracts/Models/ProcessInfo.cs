using System;

namespace Core.Contracts.Models
{
    public sealed class ProcessInfo
    {
        public String Pid { get; set; }
        public String Name { get; set; }

        public String Status { get; set; }

        public String User { get; set; }

        public Int64 WorkingSet { get; set; }
    }
}
