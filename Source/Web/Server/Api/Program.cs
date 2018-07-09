using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Api
{
    /// <summary>
    /// The application entry point class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The application entry point function.
        /// </summary>
        /// <param name="args">The input application arguments.</param>
        public static void Main(String[] args)
        {
            // Create and run web server.
            WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>()
                   .Build()
                   .Run();
        }
    }
}
