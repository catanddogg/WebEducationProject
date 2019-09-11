using BookStore.DAL.Enums;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.CategoriesController.Get
{
    public class AuthorAndCategoryViewModel
    {
        public List<AuthorAndCategoryViewModelItem> Categories { get; set; }

        public AuthorAndCategoryViewModel()
        {
            Categories = new List<AuthorAndCategoryViewModelItem>();
        }
    }

    public class AuthorAndCategoryViewModelItem
    {
        public CategoryType FirstCategoryType { get; set; }
        public CategoryType SecondCategoryType { get; set; }
        public CategoryType TrirdCategoryType { get; set; }
    }
}
