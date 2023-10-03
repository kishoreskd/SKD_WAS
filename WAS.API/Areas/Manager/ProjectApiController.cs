using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using WAS.Interface;

using WAS.Context.Manager;
using Microsoft.Extensions.Logging;

using WAS.Model;
using WAS.Utility;

namespace WAS.API.Areas.Manager
{
    [Route("pgt/api/[controller]/[action]")]
    [ApiController]
    public class ProjectApiController : ControllerBase
    {
        private readonly IProjectContext _projectContext;
        private readonly ILogger<ProjectApiController> _logger;
        public ProjectApiController(IProjectContext projectContext, ILogger<ProjectApiController> logger)
        {
            this._projectContext = projectContext;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Project> project = await _projectContext.GetAll();
                if (!COM.IsAny(project)) return NotFound();
                return Ok(project);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
