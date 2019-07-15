using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.AvtorsController.Get
{
    public class AvtorBooksViewModel
    {
        public List<AvtorBooksViewModelItemModel> avtorsBookViewModelItemModels { get; set; }
    }

    public class AvtorBooksViewModelItemModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string NameAvtor { get; set; }
        public string Publisher { get; set; }
    }
}
