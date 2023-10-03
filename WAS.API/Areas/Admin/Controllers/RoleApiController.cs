using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using WAS.Utility;
using WAS.Interface;
using WAS.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WAS.API.Controllers.Admin
{
    [Authorize]
    [Route("pgt/api/[controller]/[action]")]
    [ApiController]
    public class RoleApiController : ControllerBase
    {
        private readonly IRoleContext _roleContext;
        private readonly ILogger<RoleApiController> _logger;

        public RoleApiController(IRoleContext rolecontext, ILogger<RoleApiController> logger)
        {
            this._roleContext = rolecontext;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Role> role = await _roleContext.GetAll();

                if (!COM.IsAny(role))
                {
                    return NotFound();
                }

                return Ok(role);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCount()
        {
            try
            {
                int c = await _roleContext.GetCount();

                if (!COM.IsValidCount(c))
                {
                    return NotFound();
                }

                return Ok(new { count = c });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
