using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.AuthorsController.Put
{
    public class UpdateAuthorViewModel
    {
        public string NameAuthor { get; set; }
        public string Publisher { get; set; }
    }
}
