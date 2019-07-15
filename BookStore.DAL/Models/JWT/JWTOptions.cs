using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DAL.Models
{
    public class JWTOptions
    {
        public const string ISSUER = "MyJWTServer";// 
        public const string AUDIENCE = "https://localhost:44357/";
        private const string KEY = "secretkey_token12345!";
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
