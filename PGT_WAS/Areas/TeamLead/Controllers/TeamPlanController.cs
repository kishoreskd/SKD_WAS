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


namespace PGT_WAS.Areas.TeamLead.Controllers
{

    [Authorize(Roles = SD.ROLE.Role_TeamLead)]
    [Area(SD.ROLE.Role_TeamLead)]
    public class TeamPlanController : Controller
    {
        private readonly ILogger<TeamPlanController> _logger;

        private int _userId;
        private readonly IUnitOfWork _unitWork;
        private int _userLocationId;

        public TeamPlanController(IUnitOfWork unitOfWork, ILogger<TeamPlanController> logger)
        {
            this._unitWork = unitOfWork;
            this._logger = logger;
        }


        public IActionResult TeamInternalPlan()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> GetTaskActivity(string? month)
        {
            try
            {
                _userId = Convert.ToInt32(HttpContext.Session.GetString("user_id"));

                if (COM.IsNullOrEmpty(month))
                {
                    return NotFound();
                }


                IEnumerable<UserTasks> tActivity = await _unitWork.UserTasks.GetAll(task =>
               task.UserAccountId == _userId && task.Month == month, includeProp: $"{nameof(Employee)},{nameof(Project)},{nameof(UserTaskStatus)},Employee.Designation");

                var results = (from activity in tActivity
                               where activity.Employee.RepotingPersonId == _userId || activity.Employee.Id == _userId
                               where activity.UserAccountId != _userId
                               group activity by activity.Employee.Id into g
                               select new { Key = g.Key, Activity = g.ToList() }).ToList();

                var payLoads = (from result in results.Select(activity => activity.Activity)
                                select new
                                {
                                    Label = result.FirstOrDefault().Employee.Name,
                                    Designation = result.FirstOrDefault().Employee.Designation.DesignationName,
                                    Activity = result

                                }).ToList();


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
        [HttpPost]
        public async Task<JsonResult> GetAllTasks(string month, int teamLeadId)
        {
            try
            {
                _userId = Convert.ToInt32(HttpContext.Session.GetString("user_id"));

                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var index = Request.Form["order[0][column]"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + index + "][name]"].FirstOrDefault();
                var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                IEnumerable<UserTasks> tActivity = await _unitWork.UserTasks.GetAll(task =>
                                         task.UserAccountId == _userId && task.Month == month, includeProp: $"{nameof(Employee)},{nameof(Project)},{nameof(UserTaskStatus)},Employee.Designation");

                var results = (from activity in tActivity
                               where activity.Employee.RepotingPersonId == teamLeadId || activity.Employee.Id == teamLeadId
                               where activity.UserAccountId != _userId
                               group activity by activity.Employee.Id into g
                               select new { Key = g.Key, Activity = g.ToList() }).ToList();

                var payLoads = (from result in results.Select(activity => activity.Activity)
                                select new
                                {
                                    Label = result.FirstOrDefault().Employee.Name,
                                    Designation = result.FirstOrDefault().Employee.Designation.DesignationName,
                                    Activity = result

                                }).ToList();

                //v = Join(v);

                recordsTotal = payLoads.Count();

                var data = payLoads;

                if (length != null)
                {
                    //data = payLoads.Skip(skip).Take(pageSize).ToList();
                }

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Json(new { success = false, msg = "Error code 500 Internal error...." });
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
