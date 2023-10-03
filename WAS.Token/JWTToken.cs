using System;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WAS.Model;
using Microsoft.Extensions.Configuration;
using WAS.Context.Admin;
using WAS.Interface;
using WAS.Utility.Library;
using WAS.Utility;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WAS.JWTToken
{
    public class JWTTokenRepository : IJWTRepository
    {
        private readonly IConfiguration _config;
        private readonly IEmployeeContext _empContext;

        public JWTTokenRepository(IConfiguration config, IEmployeeContext empContext)
        {
            this._config = config;
            this._empContext = empContext;
        }

        public async Task<string> AuthenticateAsync(Login login)
        {
            Employee emp = null;

            string password = EncryptionLibrary.EncryptText(login.Password);
            emp = await _empContext.GetFirstOrDefault(user => user.UserName.ToLower() == login.UserName.ToLower() && user.Password == password, includeProp: "Location,Department,Role");

            if (!COM.IsNull(emp))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(_config["JWT:Key"]);

                var tokenDescription = new SecurityTokenDescriptor
                {
                    Issuer = _config["JWT:Audiance"],
                    Audience = _config["JWT:Issuer"],

                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Aud, _config["JWT:Audiance"]),
                        new Claim(JwtRegisteredClaimNames.Iss, _config["JWT:Issuer"]),
                        //new Claim(ClaimTypes.Role, emp.Role),
                        new Claim(SD.Claims.Role, emp.Role.RoleName),
                        new Claim(SD.Claims.Name, emp.Name),
                        new Claim(SD.Claims.Branch, emp.Location.LocationName),
                        new Claim(SD.Claims.Department, emp.Department.DepartmentName)
                    }),

                    Expires = DateTime.Now.AddHours(3),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256),
                };

                var token = tokenHandler.CreateToken(tokenDescription);
                return tokenHandler.WriteToken(token);
            }

            return null;
        }
    }

    public class Tokens
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
    public interface IJWTRepository
    {
        Task<string> AuthenticateAsync(Login login);
    }
}
