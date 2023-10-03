using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using WAS.Utility;
using WAS.Interface;
using WAS.Model;
   using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace WAS.API.Areas.Admin.Controllers
{
    [Authorize]
    [Route("pgt/api/[controller]/[action]")]
    [ApiController]
    public class HolidayApiController : ControllerBase
    {
        private readonly IHolidayContext _holidayContext;
        private readonly ILogger<HolidayApiController> _logger;

        public HolidayApiController(IHolidayContext holiday, ILogger<HolidayApiController> logger)
        {
            this._holidayContext = holiday;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Holiday> objects = await _holidayContext.GetAll();

                if (!COM.IsAny(objects))
                {
                    return NotFound();
                }

                return Ok(objects);
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
                int c = await _holidayContext.GetCount();

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
