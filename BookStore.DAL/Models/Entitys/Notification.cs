using BookStore.DAL.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.DAL.Models.Entitys
{
    public class Notification : BaseEntity
    {
        public string ImagePath { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
