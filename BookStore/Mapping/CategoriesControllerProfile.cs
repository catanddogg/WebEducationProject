using AutoMapper;
using BookStore.Common.ViewModels.CategoriesController.Get;
using BookStore.Common.ViewModels.CategoriesController.Post;
using BookStore.Common.ViewModels.CategoriesController.Put;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Mapping
{
    public class CategoriesControllerProfile : Profile
    {
        public CategoriesControllerProfile()
        {
            CreateMap<CreateCategoryViewModel, Category>();
            CreateMap<Category, CategoryByIdViewModel>();
            CreateMap<IEnumerable<Category>, AllCategoryViewModel>();
            CreateMap<UpdateCategoryViewModel, Category>();
            CreateMap<IEnumerable<Category>, AutorAndCategoryViewModel>();
            CreateMap<IEnumerable<Category>, CategoryBooksViewModel>();
        }
    }
}
