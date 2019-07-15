using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DAL.Models
{
    public class CategoriesBooksAvtors
    {
        public List<Category> Categories { get; set; }
        public List<Book> Books { get; set; }
        public List<Author> Avtors { get; set; }
        public List<Comment> Comments { get; set; }

        public CategoriesBooksAvtors()
        {
            Categories = new List<Category>();
            Books = new List<Book>();
            Avtors = new List<Author>();
            Comments = new List<Comment>();
        }
    }
}
