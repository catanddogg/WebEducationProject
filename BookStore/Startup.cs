using AutoMapper;
using BookStore.DAL.Models;
using BookStore.Services.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace BookStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
          
            string connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<BooksContext>(options =>
                 options.UseSqlServer(connection));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<BooksContext>()
                 .AddDefaultTokenProviders();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                 builder =>
                 {
                     builder.WithOrigins("http://localhost:4200")
                     .AllowAnyHeader()
                     .AllowAnyMethod();
                });
            });

            SetupJWT(services); 


            Services.Setup.Init(services);
            DAL.Setup.Init(services, connection);
                        
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "BookStore", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    c.RoutePrefix = "Home/Swagger";
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("TestOrigin");

            //app.UseExceptionHandler("/Home/Login");
            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");
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