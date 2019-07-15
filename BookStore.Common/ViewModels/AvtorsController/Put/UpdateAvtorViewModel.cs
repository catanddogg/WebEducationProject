using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.AvtorsController.Put
{
    public class UpdateAvtorViewModel
    {
        public Book Book { get; set; }
        public string NameAvtor { get; set; }
        public string Publisher { get; set; }
    }
}
