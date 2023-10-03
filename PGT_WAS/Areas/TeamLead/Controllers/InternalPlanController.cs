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
    public class InternalPlanController : Controller
    {
        private readonly ILogger<InternalPlanController> _logger;

        private int _userId;
        private readonly IUnitOfWork _unitWork;

        public InternalPlanController(IUnitOfWork unitOfWork, ILogger<InternalPlanController> logger)
        {
            this._unitWork = unitOfWork;
            this._logger = logger;
        }

        public IActionResult InternalPlan()
        {
            return View(new PrimaryuserTasks());
        }
        [HttpGet]
        public IActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PrimaryuserTasks vm)
        {
            try
            {
                _userId = Convert.ToInt32(HttpContext.Session.GetString("user_id"));

                foreach (var key in ModelState.Keys.ToList())
                {
                    if (key.StartsWith("UpdateUserTasks_VM.") || key.StartsWith("DeleteUserTasks_VM."))
                    {
                        ModelState.Remove(key);
                    }
                }

                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(InternalPlan), "InternalPlan");
                }

                List<UserTasks> tActivity = ObjectMapper(vm.PostUserTasks_VM);

                await _unitWork.UserTasks.AddRange(tActivity);
                await _unitWork.Commit();
                SD.Msg = "Activity added successfully";

                return RedirectToAction(nameof(InternalPlan), "InternalPlan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PrimaryuserTasks vm)
        {
            try
            {             

                _userId = Convert.ToInt32(HttpContext.Session.GetString("user_id"));

                foreach (var key in ModelState.Keys.ToList())
                {
                    if (key.StartsWith("PostUserTasks_VM.") || key.StartsWith("DeleteUserTasks_VM."))
                    {
                        ModelState.Remove(key);
                    }
                }

                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(InternalPlan), "InternalPlan"); ;
                }

                if (COM.IsNull(vm.UpdateUserTasks_VM.UserTaskIds) || !COM.IsValidCount(vm.UpdateUserTasks_VM.UserTaskIds.Length)) return RedirectToAction(nameof(InternalPlan), "InternalPlan");

                IEnumerable<UserTasks> usrTasks = await _unitWork.UserTasks.GetAll(task => task.UserAccountId == _userId && vm.UpdateUserTasks_VM.UserTaskIds.Contains(task.UserTasksId), includeProp: $"{nameof(Project)},{nameof(Employee)}");

                foreach (UserTasks task in usrTasks)
                {
                    task.Description = vm.UpdateUserTasks_VM.Desctiption;
                    task.ProjectId = vm.UpdateUserTasks_VM.ProjectId;
                    task.Status = vm.UpdateUserTasks_VM.Status;
                    task.StartDate = COM.GetCusomizedDate(vm.UpdateUserTasks_VM.StartDate);
                    task.EndDate = COM.GetCusomizedDate(vm.UpdateUserTasks_VM.EndDate);
                    task.UserTaskStatusId = vm.UpdateUserTasks_VM.Status;
                }

                await _unitWork.Commit();
                return RedirectToAction(nameof(InternalPlan), "InternalPlan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Remove(PrimaryuserTasks vm)
        {
            try
            {
                _userId = Convert.ToInt32(HttpContext.Session.GetString("user_id"));

                foreach (var key in ModelState.Keys.ToList())
                {
                    if (key.StartsWith("PostUserTasks_VM.") || key.StartsWith("UpdateUserTasks_VM."))
                    {
                        ModelState.Remove(key);
                    }
                }

                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(InternalPlan), "InternalPlan");
                }

                if (COM.IsNull(vm.DeleteUserTasks_VM.UserTaskIds) || !COM.IsValidCount(vm.DeleteUserTasks_VM.UserTaskIds.Length)) return RedirectToAction(nameof(InternalPlan), "InternalPlan");

                IEnumerable<UserTasks> usrTasks = await _unitWork.UserTasks.GetAll(task => task.UserAccountId == _userId && vm.DeleteUserTasks_VM.UserTaskIds.Contains(task.UserTasksId), includeProp: $"{nameof(Project)},{nameof(Employee)}");

                _unitWork.UserTasks.RemoveRange(usrTasks);
                await _unitWork.Commit();
                return RedirectToAction(nameof(InternalPlan), "InternalPlan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
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
        [HttpPost]
        public async Task<JsonResult> GetAllTasks(string month)
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
                               where activity.Employee.RepotingPersonId == _userId || activity.Employee.Id == _userId
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
        [AllowAnonymous]
        public async Task<IActionResult> GetAllUserTaskStatus()
        {
            try
            {
                IEnumerable<UserTaskStatus> status = await _unitWork.UserTaskStatus.GetAll();
                if (!COM.IsAny(status)) NotFound();

                return Ok(status);
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
               

        public List<UserTasks> ObjectMapper(PostUserTasks_VM vm)
        {
            _userId = Convert.ToInt32(HttpContext.Session.GetString("user_id"));
            List<UserTasks> usrTasks = new List<UserTasks>();

            usrTasks = vm.TeamEmployees.Select(emp => new UserTasks
            {
                EmployeeId = emp,
                Description = vm.Desctiption,
                ProjectId = vm.ProjectId,
                Status = vm.Status,
                StartDate = COM.GetCusomizedDate(vm.StartDate),
                EndDate = COM.GetCusomizedDate(vm.EndDate),
                Month = vm.Month,
                UserAccountId = _userId,
                UserTaskStatusId = vm.Status

            }).ToList();

            return usrTasks;
        }
    }
}
