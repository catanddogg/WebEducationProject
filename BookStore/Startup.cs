using BookStore.API.Hubs;
using BookStore.DAL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace BookStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly string AddTestCors = "AddTestCors";

        public void ConfigureServices(IServiceCollection services)
        {

            string connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<BooksContext>(options =>
                 options.UseSqlServer(connection));

            services.AddCors(options =>
            {
                options.AddPolicy(AddTestCors,
                builder =>
                {
                    builder
                     .AllowAnyHeader()
                     .AllowAnyMethod()
                     .AllowAnyOrigin();
                });
            });

            SetupJWT(services);


            Services.Setup.Init(services);
            DAL.Setup.Init(services, connection);

            services.AddRazorPages();

            services.AddSignalR().AddJsonProtocol(options =>
            {
                options.PayloadSerializerOptions.WriteIndented = false;
            });

            //Register the Swagger generator, defining 1 or more Swagger documents
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "BookStore", Version = "v1" });
            //});
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c =>
                //{
                //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                //    c.RoutePrefix = string.Empty;
                //});
            }
            else
            {
                app.UseHsts();
            }


            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(AddTestCors);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<SignalRHub>("/chat");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,  
                // see https://go.microsoft.com/fwlink/?linkid=864501  

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");  
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        #region Methods
            private void SetupJWT(IServiceCollection services)
            {
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = JWTOptions.ISSUER,
                            ValidateAudience = true,
                            ValidAudience = JWTOptions.AUDIENCE,
                            ValidateLifetime = true,
                            IssuerSigningKey = JWTOptions.GetSymmetricSecurityKey(),
                            ValidateIssuerSigningKey = true
                        };
                    });

                services.AddAuthorization();
            }
            #endregion Methods
        }
    }