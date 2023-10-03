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
    public class LocationController : Controller
    {
        private readonly ILocationContext _locContext;
        private readonly ILogger<LocationController> _logger;

        public LocationController(ILocationContext locContext, ILogger<LocationController> logger)
        {
            this._locContext = locContext;
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
                Location location = new Location();

                if (COM.IsValidID(id)) location = await _locContext.GetFirstOrDefault(des => des.LocationId == id);

                return View(location);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpSert(Location location)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                Location obj = await _locContext.GetFirstOrDefault(des => des.LocationId == location.LocationId);

                SD.Msg = "Location saved successfully";

                if (COM.IsNull(obj))
                {
                    await _locContext.Add(location);
                }
                else
                {
                    SD.Msg = "Location updated successfully";
                    _locContext.Update(location);
                }

                await _locContext.Commit();
                TempData[SD.Success] = SD.Msg;
                return RedirectToAction(nameof(Index), nameof(Location));
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
                Location location = await _locContext.GetFirstOrDefault(des => des.LocationId == id);

                if (COM.IsNull(location))
                {
                    return Json(new { success = false, msg = "Error while deleting" });
                }

                _locContext.Remove(location);
                await _locContext.Commit();


                return Json(new { success = true, msg = "Deleted successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Json(new { success = false, msg = "Error code 500 Internal error...." });
            }
        }


        public JsonResult GetAllLocation()
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

                var v = _locContext.GetFilterData(sortColumn, sortColumnDir, searchValue, "LocationName");

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
