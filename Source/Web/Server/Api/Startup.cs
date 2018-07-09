using System;
using System.IO;
using Api.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using static System.Diagnostics.Debug;
using Api.SignalR;

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
        /// The name of section in appsettings.json.
        /// </summary>
        private const String SITE_SECTION_NAME = "Site";

        /// <summary>
        /// API settings.
        /// </summary>
        private readonly ApiSettings _apiSettings;

        /// <summary>
        /// Site settings.
        /// </summary>
        private readonly SiteSettings _siteSettings;

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

            _siteSettings = new SiteSettings();
            configuration.GetSection(SITE_SECTION_NAME).Bind(_siteSettings);
        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The collections with used services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            Assert(services != null);

            services.AddMvc();
            services.AddSwaggerGen(ConfigureSwaggerGenerator);
            services.AddSignalR();
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

            app.UseSwagger();
            app.UseSwaggerUI(ConfigureSwaggerUi);

            ConfigureStatic(app);
            ConfigureRewriteRules(app);

            app.UseSignalR(ConfigureSignalR);
            app.UseMvc();
        }

        /// <summary>
        /// Configures rules to rewrite and redirect.
        /// </summary>
        /// <param name="app">The application builder.</param>
        private void ConfigureRewriteRules(IApplicationBuilder app)
        {
            Assert(app != null);

            var options = new RewriteOptions()
                          .AddRedirect("(.*)/$", "$1") // remove slash from the end of the URL
                          .Add(context =>
                          {
                              var request = context.HttpContext.Request;

                              // It is request to API - do nothing.
                              if (request.Path.StartsWithSegments(new PathString(_apiSettings.Prefix)))
                              {
                                  return;
                              }

                              // It is request to Swagger - do nothing.
                              if (request.Path.StartsWithSegments(new PathString(_apiSettings.Swagger.Route)))
                              {
                                  return;
                              }

                              // Redirect to site or Swagger.
                              if (Directory.Exists(_siteSettings.Location))
                              {
                                  RedirectToSite(context);
                              }
                              else
                              {
                                  RedirectToSwagger(context);
                              }
                          });

            app.UseRewriter(options);
        }

        /// <summary>
        /// Redirects to Swagger index page.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        private void RedirectToSwagger(RewriteContext context)
        {
            Assert(context != null);
            Assert(_apiSettings != null);

            var response = context.HttpContext.Response;
            response.StatusCode = StatusCodes.Status301MovedPermanently;
            context.Result = RuleResult.EndResponse;
            response.Headers[HeaderNames.Location] = _apiSettings.Swagger.Route;
        }

        /// <summary>
        /// Redirects to site index page.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        private void RedirectToSite(RewriteContext context)
        {
            Assert(context != null);
            Assert(_siteSettings != null);

            var response = context.HttpContext.Response;
            response.StatusCode = StatusCodes.Status301MovedPermanently;
            context.Result = RuleResult.EndResponse;
            response.Headers[HeaderNames.Location] = _siteSettings.Index;
        }

        /// <summary>
        /// Configures directory with static files.
        /// </summary>
        /// <param name="app"></param>
        private void ConfigureStatic(IApplicationBuilder app)
        {
            Assert(app != null);
            Assert(_siteSettings != null);

            if (Directory.Exists(_siteSettings.Location))
            {
                app.UseDefaultFiles();
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(Path.GetFullPath(_siteSettings.Location))
                });
            }
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
