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
using System.Security.Claims;
using WAS.JWTToken;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;


namespace WAS.API.Controllers.Admin
{
    [Authorize]
    [Route("pgt/api/[controller]/[action]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private readonly IEmployeeContext _empContext;
        private readonly IJWTRepository _jwtRepo;
        private readonly ILogger<EmployeeApiController> _logger;

        public EmployeeApiController(IEmployeeContext empContext, IJWTRepository jwtRepo, ILogger<EmployeeApiController> logger)
        {
            this._empContext = empContext;
            this._jwtRepo = jwtRepo;
            this._logger = logger;
        }

        //Get all employee
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Employee> emp = await _empContext.GetAll(includeProp: $"{nameof(Employee.ReportingTo)},{nameof(Employee.Department)},{nameof(Employee.Designation)},{nameof(Employee.Location)}");

                if (!COM.IsAny(emp))
                {
                    return NotFound();
                }

                return Ok(emp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        //Get team employees
   
        [HttpPost]
        public async Task<IActionResult> Get(int dep, int loc)
        {
            try
            {
                if (!COM.IsValidID(dep) && !COM.IsValidID(loc))
                {
                    return NotFound();
                }

                IEnumerable<Employee> employees = await _empContext.GetAll(data => data.DepartmentId == dep && data.LocationId == loc, includeProp: $"{nameof(Employee.ReportingTo)},{nameof(Employee.Department)},{nameof(Employee.Designation)},{nameof(Employee.Location)}");
                IQueryable<Employee> iquery = employees.AsQueryable().Where(data => data.DepartmentId == dep && data.LocationId == loc).Select(emp => emp);

                if (!COM.IsAny(employees))
                {
                    return NotFound();
                }

                return Ok(employees);
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
                int c = await _empContext.GetCount();

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
