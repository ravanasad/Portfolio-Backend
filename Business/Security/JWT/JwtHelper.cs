    using Azure;
    using Azure.Core;
    using Business.Dtos;
    using Domain.Entities.Identity;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    namespace Business.Security.JWT
    {
        public class JwtHelper : IJwtService
        {

            private readonly IConfiguration _configuration;
            private IHttpContextAccessor _contextAccessor;
            private int ExpirationTime;
            public JwtHelper(IConfiguration configuration, IHttpContextAccessor contextAccessor)
            {
                _configuration = configuration;
                ExpirationTime = Convert.ToInt32(_configuration["TokenOptions:AccessTokenExpiration"]);
                _contextAccessor = contextAccessor;
            }

            public Token CreateAccessToken(AppUser user)
            {
                Token token = new();
                SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["TokenOptions:SecurityKey"]));

                SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

                token.Expiration = DateTime.UtcNow.AddHours(ExpirationTime);

                JwtSecurityToken securityToken = new(
                    audience: _configuration["TokenOptions:Auidence"],
                    issuer: _configuration["TokenOptions:Issuer"],
                    notBefore: DateTime.Now,
                    signingCredentials: signingCredentials,
                    claims: new List<Claim> { new(JwtRegisteredClaimNames.Email, user.Email)},
                    expires: token.Expiration);

                JwtSecurityTokenHandler tokenHandler = new();
                token.AccessToken= tokenHandler.WriteToken(securityToken);
                CookieOptions option = new()
                {
                    HttpOnly = true,
                    Expires = token.Expiration,
                    SameSite = SameSiteMode.Strict,
                    Secure = true
                };
                _contextAccessor?.HttpContext?.Response.Cookies.Append("Access-Token", token.AccessToken,option);
                return token;
            }

        
        }
    }
