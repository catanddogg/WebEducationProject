using BookStore.DAL.Models.Base;
using BookStore.DAL.Models.Entitys;
using System.Collections.Generic;

namespace BookStore.DAL.Models
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<AuthorInBook> AuthorInBooks { get; set; }
        public List<Book> Books { get; set; }

        public Author()
        {
            AuthorInBooks = new List<AuthorInBook>();
            Books = new List<Book>();
        }
    }
}
