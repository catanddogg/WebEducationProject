using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DAL.Models
{
    public class JWTAndRefreshToken
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
