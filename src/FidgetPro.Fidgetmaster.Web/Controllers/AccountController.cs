using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FidgetPro.Fidgetmaster.Business.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FidgetPro.Fidgetmaster.Web.Controllers
{
    [Route("authenticate")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("")]
        public async Task<IActionResult> Authenticate(UserLoginRequest userLoginRequest)
        {
            var user = await _userManager.FindByNameAsync(userLoginRequest.UserName);

            if (user == null)
            {
                return BadRequest("Invalid user name or password.");
            }

            var loginResult = await _signInManager.CheckPasswordSignInAsync(user, userLoginRequest.Password, false);

            if (!loginResult.Succeeded)
            {
                return BadRequest("Invalid user name or password.");
            }

            // TODO: setup JWT token
            DateTime expires = DateTime.UtcNow.AddHours(24);
            var token = await CreateJwtKey(user, expires);

            var response = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new {jwt = response, expires, user.UserName});
        }

        private async Task<JwtSecurityToken> CreateJwtKey(IdentityUser user, DateTime expires)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Startup.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTimeOffset.UtcNow;

            //var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>(){
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToUnixTimeSeconds().ToString()),
            };

            //claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            JwtSecurityToken token = new JwtSecurityToken(
                "https://kevgriffin.com",
                "https://kevgriffin.com",
                claims,
                expires: expires,
                signingCredentials: credentials);

            return token;
        }

#if DEBUG
        [HttpGet("seed")]
        public async Task<IActionResult> Seed()
        {
            var result = await _userManager.CreateAsync(new IdentityUser("kevin")
            {
                Email = "kevin@kevin.com"
            }, "foobar");

            return Ok();
        }
#endif
    }
}
