using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WAS.Model;
using WAS.Interface;
using WAS.Context;
using WAS.Utility;
using WAS.Utility.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace PGT_WAS.Areas.Admin.Controllers
{
    [Area(SD.ROLE.Role_Admin)]
    [Authorize(Roles = SD.ROLE.Role_Admin)]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeContext _empContext;
        private readonly IDesignationContext _desContext;
        private readonly IDepartmentContext _depContext;
        private readonly ILocationContext _locContext;
        private readonly ILogger<EmployeeController> _logger;
        private int _userId;
        private int _userLocationId;
        public EmployeeController(IEmployeeContext empContext, IDesignationContext desContext, IDepartmentContext depContext
            , ILocationContext locContext, ILogger<EmployeeController> logger)
        {
            this._empContext = empContext;
            this._desContext = desContext;
            this._depContext = depContext;
            this._locContext = locContext;

            this._logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpSert(int? id)
        {
            try
            {
                Employee employee = new Employee();

                if (COM.IsValidID(id)) employee = await _empContext.GetFirstOrDefault(emp => emp.Id == id);

                if (!COM.IsNullOrEmpty(employee.Password))
                {
                    string password = EncryptionLibrary.DecryptText(employee.Password);
                    employee.Password = password;
                    employee.ConfirmPassword = password;
                }

                return View(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpSert(Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(employee);
                }

                Employee obj = await _empContext.GetFirstOrDefault(emp => emp.Id == employee.Id);

                SD.Msg = "Employee saved successfully";

                //employee.DOB = COM.GetFormatedDate(employee.DOB);
                string newPassword = EncryptionLibrary.EncryptText(employee.Password);
                employee.Password = newPassword;
                employee.ConfirmPassword = newPassword;

                if (COM.IsNull(obj))
                {
                    await _empContext.Add(employee);
                }
                else
                {
                    _empContext.Update(employee);
                    SD.Msg = "Designation updated successfully";
                }


                await _empContext.Commit();

                return RedirectToAction(nameof(Index), nameof(Employee));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                Employee employee = await _empContext.GetFirstOrDefault(emp => emp.Id == id);

                if (COM.IsNull(employee))
                {
                    return Json(new { success = false, msg = "Error while deleting" });
                }

                _empContext.Remove(employee);
                await _empContext.Commit();

                SD.Msg = "Employee deleted successfully";
                TempData[SD.Success] = SD.Msg;
                return Json(new { success = true, msg = "Deleted successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Json(new { success = false, msg = "Error code 500 Internal error...." });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetEmployeeByDes(string des)
        {
            try
            {

                _userId = Convert.ToInt32(HttpContext.Session.GetString("user_id"));
                _userLocationId = Convert.ToInt32(HttpContext.Session.GetString("location"));

                if (COM.IsNullOrEmpty(des))
                {
                    return NotFound();
                }

                var employees = (from emp in await _empContext.GetAll(includeProp: $"{nameof(Employee.ReportingTo)},{nameof(Employee.Department)},{nameof(Employee.Designation)},{nameof(Employee.Location)}")
                                 where emp.LocationId == _userLocationId
                                 && emp.Designation.DesignationName.ToLower().Trim() == des.ToLower().Trim()
                                 && emp.RepotingPersonId == _userId
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

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetTeamEmployees(int? teamlead)
        {
            try
            {
                _userId = Convert.ToInt32(HttpContext.Session.GetString("user_id"));
                _userLocationId = Convert.ToInt32(HttpContext.Session.GetString("location"));

                if (!COM.IsValidID(teamlead))
                {
                    return NotFound();
                }

                var employees = (from emp in await _empContext.GetAll(includeProp: $"{nameof(Employee.ReportingTo)},{nameof(Employee.Department)},{nameof(Employee.Designation)},{nameof(Employee.Location)}")
                                 where emp.LocationId == _userLocationId && emp.RepotingPersonId == teamlead || emp.Id == teamlead
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

        public JsonResult GetAllEmployee()
        {
            try
            {
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

                var v = _empContext.GetFilterData(sortColumn, sortColumnDir, searchValue, "Name", includeProp: $"{nameof(Employee.ReportingTo)},{nameof(Employee.Department)},{nameof(Employee.Designation)},{nameof(Employee.Location)}");

                //v = Join(v);

                recordsTotal = v.Count();

                var data = v;

                if (length != null)
                {
                    data = v.Skip(skip).Take(pageSize).ToList();
                }

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Json(new { success = false, msg = "Error code 500 Internal error...." });
            }
        }

        //public IEnumerable<Employee> Join(IEnumerable<Employee> employeelist)
        //{
        //    IEnumerable<Employee> des = (from employee in employeelist
        //                                 join department in _depContext.GetAll() on employee.DepartmentId equals department.DepartmentId
        //                                 join designation in _desContext.GetAll() on employee.DesignationId equals designation.DesignationId
        //                                 join location in _locContext.GetAll() on employee.LocationId equals location.LocationId
        //                                 select new Employee
        //                                 {
        //                                     Id = employee.Id,
        //                                     EmployeeId = employee.EmployeeId,
        //                                     Name = employee.Name,
        //                                     DOB = employee.DOB,
        //                                     DateOfJoining = employee.DateOfJoining,
        //                                     EmailID = employee.EmailID,
        //                                     Address = employee.Address,
        //                                     Gender = employee.Gender,
        //                                     MobileNumber = employee.MobileNumber,
        //                                     BloodGroup = employee.BloodGroup,
        //                                     TotalExperiance = employee.TotalExperiance,
        //                                     ExperianceInThisDep = employee.ExperianceInThisDep,
        //                                     TypesOfJobHandle = employee.TypesOfJobHandle,
        //                                     Timestamp = employee.Timestamp,

        //                                     Designation = designation,
        //                                     Department = department,
        //                                     Location = location,

        //                                     DesignationId = employee.DesignationId,
        //                                     DepartmentId = employee.DepartmentId,
        //                                     LocationId = employee.LocationId

        //                                 });

        //    return des;
        //}



        [HttpPost]
        public async Task<JsonResult> CheckAlreadyExist(string val)
        {
            try
            {
                if (COM.IsNullOrEmpty(val)) return Json(new { success = false });
                Employee obj = await _empContext.GetFirstOrDefault(dep => dep.EmployeeId == val);
                return COM.IsNull(obj) ? Json(new { success = false, msg = "" }) : Json(new { success = true, msg = "Already exist" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Json(new { success = false, msg = "Error code 500 Internal error...." });
            }
        }


    }
}
