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
using Microsoft.AspNetCore.Http;

namespace PGT_WAS.Areas.Admin.Controllers
{ 
    [Area(SD.ROLE.Role_Admin)]
    [Authorize(Roles = SD.ROLE.Role_Admin)]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentContext _depContext;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(IDepartmentContext depContext, ILogger<DepartmentController> logger)
        {
            this._depContext = depContext;
            this._logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpSert(int? id)
        {
            try
            {
                Department department = new Department();
                if (COM.IsValidID(id)) department = await _depContext.GetFirstOrDefault(dep => dep.DepartmentId == id);

                return View(department);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpSert(Department department)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                Department obj = await _depContext.GetFirstOrDefault(dep => dep.DepartmentId == department.DepartmentId);

                SD.Msg = "Department saved successfully";

                if (COM.IsNull(obj))
                {
                    await _depContext.Add(department);
                }
                else
                {
                    SD.Msg = "Department updated successfully";
                    _depContext.Update(department);
                }

                await _depContext.Commit();

                TempData[SD.Success] = SD.Msg;
                return RedirectToAction(nameof(Index), nameof(Department));
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
                Department department = await _depContext.GetFirstOrDefault(dep => dep.DepartmentId == id);

                if (COM.IsNull(department))
                {
                    return Json(new { success = false, msg = "Error while deleting" });
                }

                _depContext.Remove(department);
                await _depContext.Commit();


                return Json(new { success = true, msg = "Deleted successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Json(new { success = false, msg = "Error code 500 Internal error...." });
            }
        }


        public JsonResult GetAllDepartment()
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

                var v = _depContext.GetFilterData(sortColumn, sortColumnDir, searchValue, "DepartmentName");
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

        [HttpPost]
        public async Task<JsonResult> CheckAlreadyExist(string val)
        {
            try
            {
                if (COM.IsNullOrEmpty(val)) return Json(new { success = false });

                Department obj = await _depContext.GetFirstOrDefault(dep => dep.DepartmentName.ToLower() == val.ToLower());
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
