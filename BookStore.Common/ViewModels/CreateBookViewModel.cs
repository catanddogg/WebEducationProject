using BookStore.DAL.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels
{
    public class CreateBookViewModel
    {
        public string Name { get; set; }
        public IFormFile file { get; set; }
        public string Avtor { get; set; }
        public string Publisher { get; set; }
        public CategoryType Genre1 { get; set; }
        public CategoryType Genre2 { get; set; }
    }
}
