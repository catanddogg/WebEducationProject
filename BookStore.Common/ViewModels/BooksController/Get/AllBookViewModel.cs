using BookStore.Common.ViewModels.EnumsViewModel;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.BooksController.Get
{
    public class AllBookViewModel
    {
        public List<AllBookViewModelItem> Books { get; set; }

        public AllBookViewModel()
        {
            Books = new List<AllBookViewModelItem>();
        }
    }

    public class AllBookViewModelItem
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public int AuthorId { get; set; }
        public AllBookAuthorViewModelItem Author { get; set; }

        public AllBookCategoryViewModelItem Category { get; set; }
    }

    public class AllBookAuthorViewModelItem
    {
        public string NameAuthor { get; set; }
        public string Publisher { get; set; }
    }

    public class AllBookCategoryViewModelItem
    {

        public CategoryTypeViewModel FirstCategoryType { get; set; }
        public CategoryTypeViewModel SecondCategoryType { get; set; }
        public CategoryTypeViewModel TrirdCategoryType { get; set; }
    }
}
