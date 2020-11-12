using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.DAL.Models.Entitys
{
    public class PublisherInBook
    {
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }

        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
    }
}
