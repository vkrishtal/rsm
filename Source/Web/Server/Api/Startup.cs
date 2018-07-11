using System;
using Api.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using static System.Diagnostics.Debug;
using Api.SignalR;
using Core.Contracts.Services;
using Core.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Api
{
    /// <summary>
    /// The server startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The name of section in appsettings.json.
        /// </summary>
        private const String API_SECTION_NAME = "Api";

        /// <summary>
        /// The CORS rule.
        /// </summary>
        private const String ALLOW_ALL_CORS = "AllowAll";

        /// <summary>
        /// API settings.
        /// </summary>
        private readonly ApiSettings _apiSettings;

        /// <summary>
        /// Contains data from settings file.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Creates a new instance of <see cref="Startup"/>.
        /// </summary>
        /// <param name="configuration">The configuration manager that contains data from settings file.</param>
        public Startup(IConfiguration configuration)
        {
            Assert(configuration != null);

            Configuration = configuration;

            _apiSettings = new ApiSettings();
            configuration.GetSection(API_SECTION_NAME).Bind(_apiSettings);
        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The collections with used services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            Assert(services != null);

            services.AddCors(ConfigureCors);
            services.AddMvc();
            services.AddSwaggerGen(ConfigureSwaggerGenerator);
            services.AddSignalR();

            services.AddSingleton<ISystemService, SystemService>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">The environment configurations.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Assert(app != null);
            Assert(env != null);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(ALLOW_ALL_CORS);
            app.UseSwagger();
            app.UseSwaggerUI(ConfigureSwaggerUi);
            app.UseSignalR(ConfigureSignalR);
            app.UseRewriter(GetRules());
            app.UseMvc();
        }

        /// <summary>
        /// Configures CORS.
        /// </summary>
        private void ConfigureCors(CorsOptions options)
        {
            Assert(options != null);

            options.AddPolicy(ALLOW_ALL_CORS, p =>
            {
                p.AllowAnyOrigin()
                 .AllowAnyHeader()
                 .AllowAnyMethod();
            });
        }

        /// <summary>
        /// Configures rules to rewrite and redirect.
        /// </summary>
        private RewriteOptions GetRules()
        {
            Assert(_apiSettings != null);

            return new RewriteOptions()
                   .AddRedirect("(.*)/$", "$1") // remove slash from the end of the URL
                   .Add(context =>
                   {
                       var request = context.HttpContext.Request;


                       // It is request to API - do nothing.
                       if (request.Path.StartsWithSegments(new PathString(_apiSettings.Route)))
                       {
                           return;
                       }

                       // It is request to Swagger - do nothing.
                       if (request.Path.StartsWithSegments(new PathString(_apiSettings.Swagger.Route)))
                       {
                           return;
                       }

                       RedirectTo(context, _apiSettings.Swagger.Route);
                   });
        }

        /// <summary>
        /// Redirects to specified route.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <param name="route">The route to redirect.</param>
        private void RedirectTo(RewriteContext context, String route)
        {
            Assert(context != null);
            Assert(!String.IsNullOrWhiteSpace(route));

            var response = context.HttpContext.Response;
            response.StatusCode = StatusCodes.Status301MovedPermanently;
            context.Result = RuleResult.EndResponse;
            response.Headers[HeaderNames.Location] = route;
        }

        /// <summary>
        /// Configures SignalR service.
        /// </summary>
        /// <param name="routes">The SignalR route builder.</param>
        private void ConfigureSignalR(HubRouteBuilder routes)
        {
            Assert(routes != null);
            Assert(_apiSettings != null);

            routes.MapHub<MonitorHub>(_apiSettings.MonitorHubRoute);
        }

        /// <summary>
        /// Configures swagger document generator.
        /// </summary>
        /// <param name="options">The swagger options.</param>
        private void ConfigureSwaggerGenerator(SwaggerGenOptions options)
        {
            Assert(options != null);
            Assert(_apiSettings != null);

            options.SwaggerDoc(_apiSettings.Version, new Info
            {
                Title = _apiSettings.Swagger.Title,
                Version = _apiSettings.Version,
                Description = _apiSettings.Swagger.Description
            });
        }

        /// <summary>
        /// Configures swagger UI page.
        /// </summary>
        /// <param name="options">The swagger options.</param>
        private void ConfigureSwaggerUi(SwaggerUIOptions options)
        {
            Assert(options != null);
            Assert(_apiSettings != null);

            var endpoint = $"{_apiSettings.Swagger.Route}/{_apiSettings.Version}/{_apiSettings.Swagger.FileName}";
            options.SwaggerEndpoint(endpoint, _apiSettings.Swagger.Title);
        }
    }
}
