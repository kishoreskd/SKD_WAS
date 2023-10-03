using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WAS.Interface;
using WAS.JWTToken;
using WAS.Model;
using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace WAS.API.Areas.Admin.Controllers
{
    [Route("pgt/api/[controller]/[action]")]
    public class LoginApiController : ControllerBase
    {
        private readonly IJWTRepository _jwtRepo;
        private readonly ILogger<LoginApiController> _logger;
        public LoginApiController(IJWTRepository jwtRepo, ILogger<LoginApiController> logger)
        {
            this._jwtRepo = jwtRepo;
            this._logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            try
            {
                string tokenString = await _jwtRepo.AuthenticateAsync(login);
                return Ok(new { token = tokenString });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
