using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Paco.Areas.Identity;
using System;
using Microsoft.AspNetCore.Http;
using Paco.Services;
using Microsoft.Extensions.Logging;
using Paco.Entities.Models.Identity;
using Paco.Logging;
using Paco.Repositories.Database;
using Serilog;

namespace Paco
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var postgreString = Configuration.GetPostgreSqlServerConnectionString();
            var sqlString = Configuration.GetSqlServerConnectionString();

            if (!string.IsNullOrEmpty(postgreString))
            {
                services.AddDbContextFactory<ApplicationDbContext>(options => options.UseNpgsql(postgreString));
                services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(postgreString));
            }
            else if (!string.IsNullOrEmpty(sqlString))
            {
                services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(sqlString));
                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(sqlString));
            }
            else
            {
                throw new NullReferenceException("Connection string for database is not valid. You must provide valid connection string for SQL Server of PostgreSQL Server in appsettings.json");
            }
            
            services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer());
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer());
            
            services
                .AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();
            
            services.AddTransient<IUserStore<User>, IdentityStore>();

            var builder = services.AddRazorPages();
#if DEBUG
            if (_env.IsDevelopment())
            {
                // There was bug in this library and no page was ever show when activated
                //builder.AddRazorRuntimeCompilation();
            }
#endif
            
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<User>>();

            services.AddTransient<SystemManagerService>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddScoped<EmailQueueService>();
            services.AddScoped<UserInviteService>();

            services.AddRazorPages().AddRazorPagesOptions(options => 
            { 
                options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                options.Conventions.AuthorizeAreaPage("Identity", "/Account/LogOut");
                options.Conventions.AuthorizeFolder("/");
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
                
                // Sign in
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/LogOut";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;

                // Cookie settings
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.Cookie.HttpOnly = false;
                options.ExpireTimeSpan = TimeSpan.FromDays(5);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, ApplicationDbContext dataContext, IConfiguration configuration)
        {
            dataContext.Database.Migrate();
            
            Log.Logger = new LoggerConfiguration()
                .WriteTo.EntityFrameworkSink(app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IDbContextFactory<ApplicationDbContext>>())
                .CreateLogger();
            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            if (configuration.GetHttpsRedirect())
            {
                app.UseHttpsRedirection();
            }
            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
