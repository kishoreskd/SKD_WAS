using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using WAS.Model;
using WAS.Interface;
using WAS.Context;
using WAS.Utility;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace PGT_WAS.Areas.Admin.Controllers
{
    [Area(SD.ROLE.Role_Admin)]
    [Authorize(Roles = SD.ROLE.Role_Admin)]
    public class RoleController : Controller
    {
        private readonly IRoleContext _roleContext;
        private readonly ILogger<RoleController> _logger;

        public RoleController(IRoleContext rolContext, ILogger<RoleController> logger)
        {
            this._roleContext = rolContext;
            this._logger = logger;

        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpSert(int? id)
        {
            try
            {
                Role role = new Role();

                if (COM.IsValidID(id)) role = await _roleContext.GetFirstOrDefault(rol => rol.RoleID == id);

                return View(role);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpSert(Role role)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                Role obj = await _roleContext.GetFirstOrDefault(rol => rol.RoleID == role.RoleID);

                SD.Msg = "Role saved successfully";

                if (COM.IsNull(obj))
                {
                    await _roleContext.Add(role);
                }
                else
                {
                    SD.Msg = "Role updated successfully";
                    _roleContext.Update(role);
                }

                await _roleContext.Commit();
                TempData[SD.Success] = SD.Msg;
                return RedirectToAction(nameof(Index), nameof(Role));
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
                Role role = await _roleContext.GetFirstOrDefault(rol => rol.RoleID == id);

                if (COM.IsNull(role))
                {
                    return Json(new { success = false, msg = "Error while deleting" });
                }

                _roleContext.Remove(role);
                await _roleContext.Commit();

                return Json(new { success = true, msg = "Deleted successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Json(new { success = false, msg = "Error code 500 Internal error...." });
            }
        }


        public JsonResult GetAllRole()
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

                var v = _roleContext.GetFilterData(sortColumn, sortColumnDir, searchValue, "RoleName");

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
    }
}