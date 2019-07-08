using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.Services.Services
{
    public class JWTService : IJWTService
    {
        public JwtSecurityToken jwt { get; set; } 


        public ClaimsIdentity GetIdentity(string login, string password)
        {
            if(login != null && password != null)
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

        public JWTAndRefreshToken Login(string login, string password)
        {
            ClaimsIdentity identity = GetIdentity(login, password);
            if (identity == null)
            {
                jwt = null;
                return null;
            }
            DateTime timeNow = DateTime.UtcNow;
            jwt = new JwtSecurityToken(
                issuer: JWTOptions.ISSUER,
                audience: JWTOptions.AUDIENCE,
                claims: identity.Claims,
                notBefore: timeNow,
                expires: timeNow.AddMinutes(1),
                signingCredentials: new SigningCredentials(
                    JWTOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            string accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);
            string refreshToken = Guid.NewGuid().ToString();

            JWTAndRefreshToken JWTAndRefreshToken = new JWTAndRefreshToken { AccessToken = accessToken, RefreshToken = refreshToken };
            return JWTAndRefreshToken;
        }
    }
}
