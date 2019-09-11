using BookStore.DAL.Enums;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.CategoriesController.Post
{
    public class CreateCategoryViewModel
    {
        public CategoryType FirstCategoryType { get; set; }
        public CategoryType SecondCategoryType { get; set; }
        public CategoryType TrirdCategoryType { get; set; }
    }
}
