using Cabsie.API.ViewModels;
using CryptoHelper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cabsie.API.Services
{
    public interface IAuthService
    {
        AuthData GetAuthData(string id);
        string HashPassword(string password);
        bool VerifyPassword(string actualPassword, string hashedPassword);
    }

    public class AuthService : IAuthService
    {
        private int _jwtLifespan;
        private string _jwtSecret;

        public AuthService(string jwtSecret, int jwtLifespan)
        {
            _jwtLifespan = jwtLifespan;
            _jwtSecret = jwtSecret;
        }

        public AuthData GetAuthData(string id)
        {
            var expirationTime = DateTime.UtcNow.AddSeconds(_jwtLifespan);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, id)
                }),
                Expires = expirationTime,
                // new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret)),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            return new AuthData
            {
                Token = token,
                TokenExpirationTime = ((DateTimeOffset)expirationTime).ToUnixTimeSeconds(),
                Id = id
            };
        }

        public string HashPassword(string password)
            => Crypto.HashPassword(password);

        public bool VerifyPassword(string actualPassword, string hashedPassword)
            => Crypto.VerifyHashedPassword(hashedPassword, actualPassword);
    }
}
