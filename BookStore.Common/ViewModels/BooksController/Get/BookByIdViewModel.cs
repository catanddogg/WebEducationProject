using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.BooksController.Get
{
    public class BookByIdViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
