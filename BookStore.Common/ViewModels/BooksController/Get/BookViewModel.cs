using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.BooksController.Get
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public AllBookAuthorViewModelItem Author { get; set; }

        public AllBookCategoryViewModelItem Category { get; set; }
    }
}
