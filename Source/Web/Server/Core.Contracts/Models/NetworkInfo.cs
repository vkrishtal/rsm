using System;

namespace Core.Contracts.Models
{
    public sealed class NetworkInfo
    {
        public Int64 Sent { get; set; }

        public Int64 Received { get; set; }
    }
}
