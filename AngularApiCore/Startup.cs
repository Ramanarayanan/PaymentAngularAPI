using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PaymentWeb.Data;
using PaymentWeb.Services;
using PaymentWeb.business;
using BillPaymentBusness.ExceptionHandler;
using BillPaymentBusness.Interfaces;
using BillPaymentBusness.Services;
using BillPaymentDataAccess.UnitOfWork;
using UsersDataAcccesLayer;

namespace PaymentWeb
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("dbconfig.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add<ApiExceptionFilterAttribute>();
            });
            services.AddCors();
            
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            var d = new ServiceDescriptor(typeof(IUnitOfWork),
           new UnitOfWork(Configuration.GetConnectionString("PaymentConnection")));
            services.Add(d);
            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // configure DI for application services
            services.AddScoped<IUserDataService, UserDataService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOperatorService, OperatorService>();
            services.AddScoped<ICardPaymentService, CardPaymentService>();
            services.AddScoped<IPostPaidService, PostPaidService>();
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<IPaymentService, PaymentService>();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddFile("Logs/ts-{Date}.txt");
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            SeedDB.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);

            //   app.UseExceptionHandler(
            //                            options => {
            //                             options.Run(
            //                  async context =>
            //     {
            //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //context.Response.ContentType = "text/html";
            //var ex = context.Features.Get<IExceptionHandlerFeature>();
            //            if (ex != null)
            //            {
            //                var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace }";
            //                await context.Response.WriteAsync(err).ConfigureAwait(false);
            //            }
            //    });
            //               }
            //     );
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.Options.StartupTimeout = System.TimeSpan.FromSeconds(200); // <-- add this line

                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
