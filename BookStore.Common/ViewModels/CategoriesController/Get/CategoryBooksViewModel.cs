using BookStore.DAL.Enums;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.CategoriesController.Get
{
    public class CategoryBooksViewModel
    {
        public List<CategoryBooksViewModelItemModel> categoryBooksViewModelItemModels { get; set; }
    }

    public class CategoryBooksViewModelItemModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public CategoryType CategoryType { get; set; }
    }
}
