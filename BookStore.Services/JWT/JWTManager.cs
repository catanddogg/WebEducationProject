using BookStore.DAL.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.Services.JWT
{
    public static class JWTManager
    {
        public static Person Person;

        public static JwtSecurityToken jwt;

        public const string ISSUER = "MyJWTServer";// 
        public const string AUDIENCE = "https://localhost:44357/";
        const string KEY = "secretkey_token12345!";
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

        public static JWTAndRefreshToken Login(string login, string password)
        {
            ClaimsIdentity identity = GetIdentity(login, password);
            if (identity == null)
            {
                jwt =  null;
                return null;
            }
            DateTime timeNow = DateTime.UtcNow;
            jwt = new JwtSecurityToken(
                issuer: ISSUER,
                audience: AUDIENCE,
                claims: identity.Claims,
                notBefore: timeNow,
                expires: timeNow.AddMinutes(1),
                signingCredentials: new SigningCredentials(
                    GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            string accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);
            string refreshToken = Guid.NewGuid().ToString();

            JWTAndRefreshToken JWTAndRefreshToken = new JWTAndRefreshToken { AccessToken = accessToken, RefreshToken = refreshToken };
            return JWTAndRefreshToken;
        }    

        public static ClaimsIdentity GetIdentity(string login, string password)
        {
            if (login != null && password != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                };
                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }
    }   
}
