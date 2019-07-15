using AutoMapper;
using BookStore.Common.ViewModels.BooksController.Get;
using BookStore.Common.ViewModels.BooksController.Post;
using BookStore.Common.ViewModels.BooksController.Put;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Mapping
{
    public class BooksControllerProfile : Profile
    {
        public BooksControllerProfile()
        {
            CreateMap<Book, BookByIdViewModel>();
            CreateMap<IEnumerable<Book>, AllBookViewModel>();
            CreateMap<CreateBookViewModel, Book>();
            CreateMap<UpdateBookViewModel, Book>();
        }
    }
}
