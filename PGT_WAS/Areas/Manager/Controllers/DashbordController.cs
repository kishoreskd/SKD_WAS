using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WAS.Interface;
using WAS.Model;

using WAS.Utility;

namespace PGT_WAS.Areas.Manager.Controllers
{
    [Authorize]
    [Area(areaName: "Manager")]
    public class DashbordController : Controller
    {
        private readonly ILogger<DashbordController> _logger;

        private int _userId;
        private int _userLocationId;
        private string _includeEntities;

        private readonly IUnitOfWork _unitWork;

        public DashbordController(IUnitOfWork unitOfWork, ILogger<DashbordController> logger)
        {
            this._unitWork = unitOfWork;
            this._logger = logger;
            this._includeEntities = $"{nameof(Employee)},{nameof(ProjectAllocation)},{nameof(UserTaskStatus)},Employee.Designation";

        }


        public IActionResult Dashbord()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetTaskActivity(string? month, int teamLeadId)
        {
            try
            {
                _userId = Convert.ToInt32(HttpContext.Session.GetString("user_id"));

                if (COM.IsNullOrEmpty(month))
                {
                    return NotFound();
                }


                IEnumerable<UserTasks> tActivity = await _unitWork.UserTasks.GetAll(task =>
                                                           task.UserAccountId == _userId && task.Month == month, 
                                                           includeProp: _includeEntities);

                var results = (from activity in tActivity
                               where activity.Employee.RepotingPersonId == teamLeadId || activity.Employee.Id == teamLeadId
                               group activity by activity.Employee.Id into g
                               select new { Key = g.Key, Activity = g.ToList() }).ToList();

                var payLoads = (from result in results.Select(activity => activity.Activity)
                                select new
                                {
                                    Label = result.FirstOrDefault().Employee.Name,
                                    Designation = result.FirstOrDefault().Employee.Designation.DesignationName,
                                    Activity = result

                                }).ToList();


                //IEnumerable<string> labels = results.Select(act => act.Activity.Select(activity => activity.Employee.Name).Distinct()).ToList();

                if (!COM.IsAny(payLoads))
                {
                    return NotFound();
                }

                return Ok(payLoads);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTeamEmployees()
        {
            try
            {
                _userId = Convert.ToInt32(HttpContext.Session.GetString("user_id"));
                _userLocationId = Convert.ToInt32(HttpContext.Session.GetString("location"));

                if (!COM.IsValidCount(_userId))
                {
                    return NotFound();
                }

                var employees = (from emp in await _unitWork.Employee.GetAll(includeProp: $"{nameof(Employee.ReportingTo)},{nameof(Employee.Department)},{nameof(Employee.Designation)},{nameof(Employee.Location)}")
                                 where emp.RepotingPersonId == _userId
                                 select emp);


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

    }
}
