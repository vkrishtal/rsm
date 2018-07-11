using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Core.Extensions
{
    internal static class DriveInfoExtensions
    {
        public static IEnumerable<DriveInfo> WhereFixed(this IEnumerable<DriveInfo> self)
        {
            return self.Where(drive =>
            {
                try
                {
                    return drive.DriveType == DriveType.Fixed;
                }
                catch
                {
                    return false;
                }
            });
        }
    }
}
