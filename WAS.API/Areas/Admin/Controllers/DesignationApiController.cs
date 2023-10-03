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
    public class DesignationApiController : ControllerBase
    {
        private readonly IDesignationContext _desContext;
        private readonly ILogger<DesignationApiController> _logger;

        public DesignationApiController(IDesignationContext _desContext, ILogger<DesignationApiController> logger)
        {
            this._desContext = _desContext;
            this._logger = logger;

        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Designation> des = await _desContext.GetAll();

                if (!COM.IsAny(des))
                {
                    return NotFound();
                }

                return Ok(des);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }    

        [HttpPost]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                IEnumerable<Designation> des = await _desContext.GetAll(des => des.DepartmentId == Convert.ToInt32(id));

                if (COM.IsNull(des))
                {
                    return NotFound();
                }

                return Ok(des);
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
                int c = await _desContext.GetCount();

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
