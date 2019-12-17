            using AutoMapper;
using BookStore.Common.ViewModels.CategoriesController.Get;
using BookStore.Common.ViewModels.CategoriesController.Post;
using BookStore.Common.ViewModels.CategoriesController.Put;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Services.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryViewModel, Category>();
            CreateMap<Category, CategoryByIdViewModel>();

            CreateMap<Category, AllCategoryViewModelItem>();

            CreateMap<UpdateCategoryViewModel, Category>();

            CreateMap<Category, AuthorAndCategoryViewModelItem>();

            CreateMap<Category, CategoryBooksViewModelItem>();
        }
    }
}
