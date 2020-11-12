using BookStore.DAL.Models.Base;
using System.Collections.Generic;

namespace BookStore.DAL.Models.Entitys
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<PublisherInBook> PublisherInBooks { get; set; }
        public List<Book> Books { get; set; }

        public Publisher()
        {
            PublisherInBooks = new List<PublisherInBook>();
            Books = new List<Book>(); 
        }
    }
}
