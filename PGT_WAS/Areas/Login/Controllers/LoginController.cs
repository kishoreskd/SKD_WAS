using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WAS.Utility;
using WAS.Utility.Library;

using WAS.Interface;
using LM = WAS.Model;

using WAS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WAS.JWTToken;
using WAS.API.Areas.Admin.Controllers;
using Microsoft.Extensions.Logging;

namespace PGT_WAS.Areas.Login.Controllers
{
    [Area(SD.ROLE.Role_Login)]
    public class LoginController : Controller
    {
        private readonly IEmployeeContext _employeeContext;
        private readonly IConfiguration _config;
        private readonly IJWTRepository _jwtRepo;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IEmployeeContext employeeContext, IConfiguration config, IJWTRepository jwtRepo, ILogger<LoginController> logger)
        {
            this._jwtRepo = jwtRepo;
            this._employeeContext = employeeContext;
            this._config = config;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View(new LM.Login());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LM.Login login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(login);
                }

                string token = await _jwtRepo.AuthenticateAsync(login);

                if (!COM.IsNullOrEmpty(token))
                {
                    if (!COM.IsNullOrEmpty(token))
                    {
                        string password = EncryptionLibrary.EncryptText(login.Password);
                        Employee emp = await _employeeContext.GetFirstOrDefault(employee => employee.UserName == login.UserName && employee.Password == password, includeProp: "Role");
                        if (!COM.IsNull(emp))
                        {
                            HttpContext.Session.SetString("token", token);
                            HttpContext.Session.SetString("user_name", emp.Name);
                            HttpContext.Session.SetString("role", emp.Role.RoleName);
                            HttpContext.Session.SetString("user_id", emp.Id.ToString());
                            HttpContext.Session.SetString("location", emp.LocationId.ToString());


                            return RedirectToAction("Dashbord", "Dashbord", new { area = emp.Role.RoleName });
                        }
                    }
                }

                return View(login);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            try
            {
                CookieOptions option = new CookieOptions();

                //if (Request.Cookies["EventChannel"] != null)
                //{
                //    option.Expires = DateTime.Now.AddDays(-1);
                //    Response.Cookies.Append("EventChannel", "", option);
                //}

                HttpContext.Session.Clear();
                Response.Cookies.Delete(".pgt_was");

                return RedirectToAction("Login", "Login", new { area = SD.ROLE.Role_Login });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }

    }
}
