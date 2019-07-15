using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.PersonController.Put
{
    public class UpdatePersonViewModel
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
