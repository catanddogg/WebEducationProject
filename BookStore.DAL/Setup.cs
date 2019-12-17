using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.DAL.Repositories.Dapper;
using BookStore.DAL.Repositories.EntityFramework;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BookStore.DAL
{
    public class Setup
    {
        public static void Init(IServiceCollection services, string connection)
        {
              EntityFramework(services);
              //Dapper(services, connection);
        }

        private static void EntityFramework(IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
        }

        private static void Dapper(IServiceCollection services, string connection)
        {
            services.AddTransient<IDbConnection, SqlConnection>(provider =>  new SqlConnection(connection));
            services.AddTransient<IBookRepository, DapperBookRepository>();
            services.AddTransient<IAuthorRepository, DapperAuthorRepository>();
            services.AddTransient<ICategoryRepository, DapperCategoryRepository>();
            services.AddTransient<IPersonRepository, DapperPersonRepository>();
            services.AddTransient<ICommentRepository, DapperCommentRepository>();
            services.AddTransient<INotificationRepository, DapperNotificationRepository>();
        }
    }
}
