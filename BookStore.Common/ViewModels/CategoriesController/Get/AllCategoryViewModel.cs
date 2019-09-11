using BookStore.DAL.Enums;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.CategoriesController.Get
{
    public class AllCategoryViewModel
    {
        public List<AllCategoryViewModelItem> Categories { get; set; }

        public AllCategoryViewModel()
        {
            Categories = new List<AllCategoryViewModelItem>();
        }
    }

    public class AllCategoryViewModelItem
    {
        public CategoryType FirstCategoryType { get; set; }
        public CategoryType SecondCategoryType { get; set; }
        public CategoryType TrirdCategoryType { get; set; }
    }
}
