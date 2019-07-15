using BookStore.DAL.Enums;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.CategoriesController.Post
{
    public class CreateCategoryViewModel
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public CategoryType CategoryType { get; set; }
    }
}
