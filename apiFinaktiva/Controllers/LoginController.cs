using apiFinaktiva.Helpers;
using apiFinaktiva.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace apiFinaktiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        public static LoginData user = new LoginData();
        private readonly IConfiguration _configuration;
        AuthHelper ah = new AuthHelper();
        //private readonly IUserService _userService;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
           // _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Login>> RegisterGetToken(Login request)
        {
            
            ah.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.UserName = request.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(Login request)
        {
            if (user.UserName != request.UserName)
            {
                return BadRequest("User not found.");
            }

            if (!ah.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(request);
            return Ok(token);
        }

        private string CreateToken(Login login)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.UserName),
                new Claim(ClaimTypes.Role, "Sup"),
               // new Claim(ClaimTypes.Role, "Sup")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
