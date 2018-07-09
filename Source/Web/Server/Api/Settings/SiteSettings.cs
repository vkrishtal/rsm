using System;

namespace Api.Settings
{
    /// <summary>
    /// Represents DTO for working on site settings.
    /// </summary>
    public sealed class SiteSettings
    {
        /// <summary>
        /// The path to site directory.
        /// </summary>
        public String Location { get; set; }

        /// <summary>
        /// The name of index file.
        /// </summary>
        public String Index { get; set; }
    }
}
