using Library.BLL.Services;
using Library.DAL;
using Library.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    [Route("token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration configuration;
        private readonly IUserService userService;
        private readonly ApplicationContext context;
        
        public TokenController(IConfiguration configuration, ApplicationContext context, IUserService userService)
        {
            this.context = context;
            this.userService = userService;
            this.configuration = configuration;
        }

        [HttpPost("token")]
        public IActionResult Token(string username, string password)
        {
            ClaimsIdentity identity = GetIdentity(username, password);

            if(identity is null)
            {
                return BadRequest(new { ErrorText = "Неверные имя пользователя и/или пароль"});
            }

            DateTime now = DateTime.UtcNow;

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var res = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };
            return null;
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            UserInfo user = userService.GetByLoginAndPassword(username, password);

            if(!(user is null))
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Role)
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultRoleClaimType, ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }
    }
}
