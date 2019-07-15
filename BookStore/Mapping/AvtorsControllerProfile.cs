using AutoMapper;
using BookStore.Common.ViewModels.AvtorsController.Get;
using BookStore.Common.ViewModels.BooksController.Post;
using BookStore.Common.ViewModels.BooksController.Put;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Mapping
{
    public class AvtorsControllerProfile : Profile
    {
        public AvtorsControllerProfile()
        {
            CreateMap<Avtor, AvtorByIdViewModel>();
            CreateMap<UpdateBookViewModel, Avtor>();
            CreateMap<CreateBookViewModel, Avtor>();
            CreateMap<IEnumerable<Avtor>, AllAvtorViewModel>();
            CreateMap<IEnumerable<Avtor>, AvtorBooksViewModel>();
            CreateMap<IEnumerable<Avtor>, PublishersBooksViewModel>();
        }
    }
}
