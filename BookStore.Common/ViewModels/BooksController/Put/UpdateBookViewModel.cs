using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.BooksController.Put
{
    public class UpdateBookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
