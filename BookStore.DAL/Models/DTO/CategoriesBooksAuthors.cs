using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DAL.Models
{
    public class CategoriesBooksAuthors
    {
        public List<Category> Categories { get; set; }
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }
        public List<Comment> Comments { get; set; }

        public CategoriesBooksAuthors()
        {
            Categories = new List<Category>();
            Books = new List<Book>();
            Authors = new List<Author>();
            Comments = new List<Comment>();
        }
    }
}
