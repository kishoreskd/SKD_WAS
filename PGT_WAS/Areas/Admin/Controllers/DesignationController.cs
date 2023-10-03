using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WAS.Model;
using WAS.Interface;
using WAS.Context.Admin;
using WAS.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace PGT_WAS.Areas.Admin.Controllers
{
    [Area(SD.ROLE.Role_Admin)]
    [Authorize(Roles = SD.ROLE.Role_Admin)]
    public class DesignationController : Controller
    {
        private readonly IDesignationContext _desContext;
        private readonly IDepartmentContext _depContext;
        private readonly ILogger<DesignationController> _logger;

        public DesignationController(IDesignationContext desContext, IDepartmentContext depContext, ILogger<DesignationController> logger)
        {
            this._desContext = desContext;
            this._depContext = depContext;
            this._logger = logger;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                Designation designation = new Designation();
                return View(designation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpSert(int? id)
        {
            try
            {
                Designation designation = new Designation();

                if (COM.IsValidID(id)) designation = await _desContext.GetFirstOrDefault(des => des.DesignationId == id);

                return View(designation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpSert(Designation designation)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(designation);
                }

                Designation obj = await _desContext.GetFirstOrDefault(des => des.DesignationId == designation.DesignationId);

                SD.Msg = "Designation saved successfully";

                if (COM.IsNull(obj))
                {
                    await _desContext.Add(designation);
                }
                else
                {
                    SD.Msg = "Designation updated successfully";
                    _desContext.Update(designation);
                }

                await _desContext.Commit();
                TempData[SD.Success] = SD.Msg;
                return RedirectToAction(nameof(Index), nameof(Designation));
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
                Designation designation = await _desContext.GetFirstOrDefault(des => des.DesignationId == id);

                if (COM.IsNull(designation))
                {
                    return Json(new { success = false, msg = "Error while deleting" });
                }

                _desContext.Remove(designation);
                await _desContext.Commit();


                return Json(new { success = true, msg = "Deleted successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Json(new { success = false, msg = "Error code 500 Internal error...." });
            }
        }


        public async Task<JsonResult> GetAllDesignation()
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

                var v = _desContext.GetFilterData(sortColumn, sortColumnDir, searchValue, "DesignationName");

                v = await Join(v);

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
        public async Task<JsonResult> CheckAlreadyExist(int dep, string des)
        {
            try
            {
                if (!COM.IsValidID(dep)) return Json(new { success = false });
                if (COM.IsNullOrEmpty(des)) return Json(new { success = false });

                int count = (from designation in await _desContext.GetAll(dsng => dsng.DepartmentId == dep)
                             where designation.DesignationName.ToLower().Trim() == des.ToLower().Trim()
                             select designation).Count();

                return !COM.IsValidCount(count) ? Json(new { success = false, msg = "" }) : Json(new { success = true, msg = "Already exist" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Json(new { success = false, msg = "Error code 500 Internal error...." });
            }
        }


        public async Task<IEnumerable<Designation>> Join(IEnumerable<Designation> designationlist)
        {
            IEnumerable<Designation> des = (from desingnation in designationlist
                                            join department in await _depContext.GetAll() on desingnation.DepartmentId equals department.DepartmentId
                                            select new Designation
                                            {
                                                Department = department,
                                                DesignationName = desingnation.DesignationName,
                                                DesignationId = desingnation.DesignationId,
                                                DepartmentId = desingnation.DepartmentId
                                            });

            return des;
        }
    }
}
