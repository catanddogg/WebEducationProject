using BookStore.Services.Interfaces;
using BookStore.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Services
{
    public class Setup
    {
        public static void Init(IServiceCollection services)
        {
            services.AddTransient<IHomeService, HomeService>();
            services.AddTransient<IJWTService, JWTService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IAvtorService, AvtorService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<ICommentService, CommentService>();
        }
    }
}
