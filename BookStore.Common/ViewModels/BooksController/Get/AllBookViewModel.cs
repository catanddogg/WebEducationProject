using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.BooksController.Get
{
    public class AllBookViewModel
    {
        public List<AllBookViewModelItemModel> Books { get; set; }
    }

    public class AllBookViewModelItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

    }

}
