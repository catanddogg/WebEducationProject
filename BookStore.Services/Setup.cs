﻿using AutoMapper;
using BookStore.Services.Interfaces;
using BookStore.Services.Mapping;
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
            IMapper mapper = new MapperConfiguration(config =>
            {
                config.AddProfile<AuthorProfile>();
                config.AddProfile<BookProfile>();
                config.AddProfile<CategoryProfile>();
                config.AddProfile<PersonProfile>();
                config.AddProfile<NotificationProfile>();
            })
            .CreateMapper();

            services.AddSingleton(mapper);

            services.AddTransient<IHomeService, HomeService>();
            services.AddTransient<IJWTService, JWTService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<INotificationService, NotificationService>();
        }
    }
}
