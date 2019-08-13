using AspNet.Security.OpenIdConnect.Primitives;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ICMS.Entities.Main;
using ICMS.Repositories.Context;
using ICMS.Web.TokenProvider;
using ICMS.Repositories.Framework.Interface;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ICMS.Repositories.Framework.Implementation;
using OpenIddict.Core;
using OpenIddict.Models;
using Serilog;
using ICMS.Service.Implementation;
using ICMS.Service.Interface;
using ICMS.Web.Attribute;
using Pomelo.EntityFrameworkCore.MySql;
using MySql.Data.MySqlClient;

namespace ICMS.Web
{
    public class Startup
    {
        private const string ConfirmEmailTokenProviderName = "ConfirmEmail";
        private readonly IHostingEnvironment _env;
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                //builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin());

                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost"));
            });

            services.AddMvc();

            services.AddOpenIddict().AddEntityFrameworkCoreStores<ApplicationDbContext>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                // Configure the context to use Microsoft SQL Server.
                //MSSQL
                //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

                //MySQL
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"));

                // Register the entity sets needed by OpenIddict.
                // Note: use the generic overload if you need
                // to replace the default OpenIddict entities.
                options.UseOpenIddict();
            });
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the Identity services.
            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddTokenProvider<ConfirmEmailTokenProvider<User>>(ConfirmEmailTokenProviderName);

            services.Configure<IdentityOptions>(o =>
            {
                o.Password.RequiredLength = 8;
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = true;
                o.Password.RequireUppercase = true;
                o.Password.RequireNonAlphanumeric = false;

                o.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                o.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                o.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;

                // Token Provider
                o.Tokens.EmailConfirmationTokenProvider = ConfirmEmailTokenProviderName;
            });

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.Name = ".ICMSSessionCookies";
                options.IdleTimeout = TimeSpan.FromHours(2);
            });

            services.AddAuthentication();

            services.AddMemoryCache();

            // Main Repository
            services.AddScoped<IEFRepository, EFRepository<ApplicationDbContext>>();

            services.AddScoped<SharedDataAttribute>();

            // Services            
            services.AddScoped<IAccountService, AccountServiceImpl>();
            services.AddScoped<IQueryService, QueryServiceImpl>();
            services.AddScoped<IValidationService, ValidationServiceImpl>();
            services.AddScoped<ISeedService, SeedServiceImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });

            InitializeAsync(app.ApplicationServices, CancellationToken.None).GetAwaiter().GetResult();
        }

        private async Task InitializeAsync(IServiceProvider services, CancellationToken cancellationToken)
        {
            // Create a new service scope to ensure the database context is correctly disposed when this methods returns.
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await context.Database.EnsureCreatedAsync();
            }
        }
    }
}
