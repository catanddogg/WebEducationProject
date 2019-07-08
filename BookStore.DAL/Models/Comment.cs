using BookStore.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DAL.Models
{
    public class Comment : BaseEntity
    {
        public string UserName { get; set; }
        public string Message { get; set; }
        public DateTime createTime { get; set; }
    }
}