using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("token")]
        public IActionResult Login([FromBody]UserModel user)
        {
            //Checking Unauthorized
            IActionResult response = Unauthorized();

            //Authenticate user
            var loginUser = Authenticate(user);

            if (loginUser != null)
            {
                var tokenString = GenerateToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;

        }

        //Generating token
        private string GenerateToken(UserModel loginUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],    //header
                _config["Jwt:Issuer"],
            expires: DateTime.Now.AddMinutes(2),
            signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //Authenticating user
        private object Authenticate(UserModel user)
        {
            UserModel loginUser = null;
            //validating content
            if (user.UserName == "Arshin" && user.Password=="Pass")
            {
                loginUser = new UserModel
                {
                    UserName = "Arshin",
                    Password = "Pass"
                };
            }
            return loginUser;
        }
    }
}
