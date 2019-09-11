using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.AuthorsController.Post
{
    public class CreateAuthorViewModel
    {
        public string NameAuthor { get; set; }
        public string Publisher { get; set; }
    }
}
