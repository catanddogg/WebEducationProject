using BookStore.DAL.Models.Base;
using BookStore.DAL.Models.Entitys;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.DAL.Models
{
    [Table("Categories")]
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<CategoryInBook> CategoryInBooks { get; set; }
        public List<Book> Books { get; set; }

        public Category()
        {
            CategoryInBooks = new List<CategoryInBook>();
            Books = new List<Book>();
        }
    }
}
