using BookStore.DAL.Enums;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.CategoriesController.Get
{
    public class CategoryBooksViewModel
    {
        public List<CategoryBooksViewModelItem> Categories { get; set; }

        public CategoryBooksViewModel()
        {
            Categories = new List<CategoryBooksViewModelItem>();
        }
    }

    public class CategoryBooksViewModelItem
    {
        public CategoryType FirstCategoryType { get; set; }
        public CategoryType SecondCategoryType { get; set; }
        public CategoryType TrirdCategoryType { get; set; }
    }
}
