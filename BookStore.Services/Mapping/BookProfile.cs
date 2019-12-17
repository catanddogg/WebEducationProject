using AutoMapper;
using BookStore.Common.ViewModels.BooksController.Get;
using BookStore.Common.ViewModels.BooksController.Post;
using BookStore.Common.ViewModels.BooksController.Put;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Services.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookByIdViewModel>();

            CreateMap<Book, BookViewModel>()
                .ForMember(destination => destination.BookId, source => source.MapFrom(src => src.Id))
                .ForMember(destination => destination.Author, source => source.MapFrom(src => src.Author))
                .ForMember(destination => destination.Category, source => source.MapFrom(src => src.Category))
                .ForMember(destination => destination.Name, source => source.MapFrom(src => src.Name))
                .ForMember(destination => destination.Path, source => source.MapFrom(src => src.Path));

            CreateMap<Book, AllBookViewModelItem>()
               .ForMember(destination => destination.BookId, source => source.MapFrom(src => src.Id))
               .ForMember(destination => destination.AuthorId, source => source.MapFrom(src => src.AuthorId))
               .ForMember(destination => destination.Author, source => source.MapFrom(src => src.Author))
               .ForMember(destination => destination.Category, source => source.MapFrom(src => src.Category))
               .ForMember(destination => destination.Name, source => source.MapFrom(src => src.Name))
               .ForMember(destination => destination.Path, source => source.MapFrom(src => src.Path));

            CreateMap<Category, AllBookCategoryViewModelItem>()
                .ForMember(destination => destination.FirstCategoryType, source => source.MapFrom(src => src.FirstCategoryType))
                .ForMember(destination => destination.SecondCategoryType, source => source.MapFrom(src => src.SecondCategoryType))
                .ForMember(destination => destination.TrirdCategoryType, source => source.MapFrom(src => src.TrirdCategoryType))
                .ForAllOtherMembers(destination => destination.Ignore());

            CreateMap<Author, AllBookAuthorViewModelItem>()
                .ForMember(destination => destination.NameAuthor, source => source.MapFrom(src => src.NameAuthor))
                .ForMember(destination => destination.Publisher, source => source.MapFrom(src => src.Publisher))
                .ForAllOtherMembers(destination => destination.Ignore());

            CreateMap<BookViewModel, Book>()
                .ForMember(destination => destination.Id, source => source.MapFrom(src => src.BookId));

            CreateMap<BookViewModel, Book>()
                .ForMember(destination => destination.Id, source => source.MapFrom(src => src.BookId));
        }
    }
}
