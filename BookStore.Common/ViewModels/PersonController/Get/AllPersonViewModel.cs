using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.PersonController.Get
{
    public class AllPersonViewModel
    {
        public List<AllPersonViewModelItem> Persons { get; set; }

        public AllPersonViewModel()
        {
            Persons = new List<AllPersonViewModelItem>();
        }
    }

    public class AllPersonViewModelItem
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }

        public string RefreshToken { get; set; }
    }
}
