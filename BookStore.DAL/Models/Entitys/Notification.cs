using BookStore.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DAL.Models.Entitys
{
    public class Notification : BaseEntity
    {
        public string ImagePath { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
