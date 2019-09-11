using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface IJWTService
    {
        JwtSecurityToken jwt { get; set; }
        Task<JWTAndRefreshToken> Login(string login, string password);
    }
}
