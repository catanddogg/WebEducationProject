using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public class JWTService : IJWTService
    {
        #region Properties & Variables
        public JwtSecurityToken jwt { get; set; }

        private readonly IPersonRepository _personRepository;
        #endregion Properties & Variables

        #region Constructors
        public JWTService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        #endregion Constructors

        #region Public Methods
        public async Task<JWTAndRefreshToken> LoginAsync(string login, string password)
        {
            Person person = await _personRepository.GetPersonByLoginAndPasswordAsync(login, password);
            if (person != null)
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
                person.RefreshToken = refreshToken;
                await _personRepository.UpdateAsync(person);

                JWTAndRefreshToken JWTAndRefreshToken = new JWTAndRefreshToken { AccessToken = accessToken, RefreshToken = refreshToken };

                return JWTAndRefreshToken;
            }
            return null;
        }
        #endregion Public Methods


        #region Private Methods
        private ClaimsIdentity GetIdentity(string login, string password)
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
        #endregion Private Methods
    }
}
