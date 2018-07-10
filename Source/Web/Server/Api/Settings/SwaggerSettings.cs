using System;

namespace Api.Settings
{
    /// <summary>
    /// Represents DTO for working on Swagger settings.
    /// </summary>
    public sealed class SwaggerSettings
    {
        /// <summary>
        /// The relative route to navigate to Swagger page.
        /// </summary>
        public String Route { get; set; }

        /// <summary>
        /// The title on Swagger page.
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// The API description on Swagger page.
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// The Swagger file name.
        /// </summary>
        public String FileName { get; set; }
    }
}
