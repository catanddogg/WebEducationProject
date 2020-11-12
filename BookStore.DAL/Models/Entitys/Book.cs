using BookStore.DAL.Models.Base;
using BookStore.DAL.Models.Entitys;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.DAL.Models
{
    [Table("Books")]
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        public List<CategoryInBook> CategoryInBooks { get; set; }
        public List<Category> Categories { get; set; }

        public List<AuthorInBook> AuthorInBooks { get; set; }
        public List<Author> Authors { get; set; }

        public List<PublisherInBook> PublisherInBooks { get; set; }
        public List<Publisher> Publishers { get; set; }

        public Book()
        {
            CategoryInBooks = new List<CategoryInBook>();
            Categories = new List<Category>();
            AuthorInBooks = new List<AuthorInBook>();
            Authors = new List<Author>();
            PublisherInBooks = new List<PublisherInBook>();
            Publishers = new List<Publisher>();
        }
    }
}
