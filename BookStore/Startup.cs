using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.DAL.Repositories;
using BookStore.DAL.Repositories.Dapper;
using BookStore.DAL.Repositories.EntityFramework;
using BookStore.Services.Interfaces;
using BookStore.Services.JWT;
using BookStore.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;

namespace BookStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BooksContext>(options =>
                 options.UseSqlServer(connection));

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();
            });
          
            SetupJWT(services);

            SetupServices(services);

            EntityFrameworkRepository(services);
            //DapperRepository(services, connection);

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
                        ValidIssuer = JWTManager.ISSUER,
                        ValidateAudience = true,
                        ValidAudience = JWTManager.AUDIENCE,
                        ValidateLifetime = true,
                        IssuerSigningKey = JWTManager.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                });
            services.AddAuthorization();
        }

        private void SetupServices(IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IAvtorService, AvtorService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IPersonService, PersonService>();
        }

        private void EntityFrameworkRepository(IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAvtorRepository, AvtorRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
        }

        private void DapperRepository(IServiceCollection services, string connection)
        {
            services.AddTransient<IBookRepository, DapperBookRepository>(provider => new DapperBookRepository(connection)); 
            services.AddTransient<IAvtorRepository, DapperAvtorRepository>(provider => new DapperAvtorRepository(connection));
            services.AddTransient<ICategoryRepository, DapperCategoryRepository>(provider => new DapperCategoryRepository(connection));
            services.AddTransient<IPersonRepository, DapperPersonRepository>(provider => new DapperPersonRepository(connection));
        }
        #endregion Methods
    }
}