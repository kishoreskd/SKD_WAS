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
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace WAS.API.Controllers.Admin
{
    [Authorize]
    [Route("pgt/api/[controller]/[action]")]
    [ApiController]
    public class LocationApiController : ControllerBase
    {
        private readonly ILocationContext _locContext;
        private readonly ILogger<LocationApiController> _logger;

        public LocationApiController(ILocationContext locContext, ILogger<LocationApiController> logger)
        {
            this._locContext = locContext;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCount()
        {
            try
            {
                int c = await _locContext.GetCount();

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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Location> loc = await _locContext.GetAll();

                if (!COM.IsAny(loc))
                {
                    return NotFound();
                }

                return Ok(loc);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
