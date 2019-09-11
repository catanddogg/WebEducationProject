using AutoMapper;
using BookStore.Common.ViewModels.AuthorsController.Get;
using BookStore.Common.ViewModels.BooksController.Post;
using BookStore.Common.ViewModels.BooksController.Put;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Services.Mapping
{
    public class AuthorsControllerProfile : Profile
    {
        public AuthorsControllerProfile()
        {
            CreateMap<Author, AuthorByIdViewModel>();
            CreateMap<UpdateBookViewModel, Author>();
            CreateMap<CreateBookViewModel, Author>();

            CreateMap<Author, AllAuthorViewModelItem>();

            CreateMap<Author, PublishersBooksViewModelItem>();
        }
    }
}
