using BookStore.DAL.Interfaces;
using BookStore.DAL.Repositories.Dapper;
using BookStore.DAL.Repositories.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BookStore.DAL
{
    public class Setup
    {
        public static void Init(IServiceCollection services, string connection)
        {
            //EntityFramework(services);
            Dapper(services, connection);
        }

        private static void EntityFramework(IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAvtorRepository, AvtorRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
        }

        private static void Dapper(IServiceCollection services, string connection)
        {
            services.AddTransient<IDbConnection, SqlConnection>(provider =>  new SqlConnection(connection));
            services.AddTransient<IBookRepository, DapperBookRepository>();
            services.AddTransient<IAvtorRepository, DapperAvtorRepository>();
            services.AddTransient<ICategoryRepository, DapperCategoryRepository>();
            services.AddTransient<IPersonRepository, DapperPersonRepository>();
            services.AddTransient<ICommentRepository, DapperCommentRepository>();
        }
    }
}
