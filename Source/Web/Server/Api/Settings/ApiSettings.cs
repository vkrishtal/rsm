using System;

namespace Api.Settings
{
    /// <summary>
    /// Represents a DTO for working on API settings.
    /// </summary>
    public sealed class ApiSettings
    {
        /// <summary>
        /// The API version.
        /// </summary>
        public String Version { get; set; }

        /// <summary>
        /// The API prefix in URL.
        /// </summary>
        public String Route { get; set; }

        /// <summary>
        /// The route to SignalR connection.
        /// </summary>
        public String MonitorHubRoute { get; set; }

        /// <summary>
        /// Swagger settings.
        /// </summary>
        public SwaggerSettings Swagger { get; set; } = new SwaggerSettings();
    }
}
