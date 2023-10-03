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
    public class HolidayController : Controller
    {
        private readonly IHolidayContext _holidayContext;
        private readonly ILogger<HolidayController> _logger;

        public HolidayController(IHolidayContext holidayContext, ILogger<HolidayController> logger)
        {
            _holidayContext = holidayContext;
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
                Holiday holiday = new Holiday();

                if (COM.IsValidID(id)) holiday = await _holidayContext.GetFirstOrDefault(hol => hol.HolidayId == id);

                return View(holiday);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpSert(Holiday holiday)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(holiday);
                }

                Holiday obj = await _holidayContext.GetFirstOrDefault(hol => hol.HolidayId == holiday.HolidayId);

                SD.Msg = "Holiday saved successfully";

                if (COM.IsNull(obj))
                {
                    await _holidayContext.Add(holiday);
                }
                else
                {
                    SD.Msg = "Holiday updated successfully";
                    _holidayContext.Update(holiday);
                }

                await _holidayContext.Commit();
                TempData[SD.Success] = SD.Msg;
                return RedirectToAction(nameof(Index), nameof(Holiday));
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
                Holiday department = await _holidayContext.GetFirstOrDefault(hol => hol.HolidayId == id);

                if (COM.IsNull(department))
                {
                    return Json(new { success = false, msg = "Error while deleting" });
                }

                _holidayContext.Remove(department);
                await _holidayContext.Commit();


                return Json(new { success = true, msg = "Holiday deleted successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Json(new { success = false, msg = "Error code 500 Internal error...." });
            }
        }

        public JsonResult GetAllHolidays()
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

                var v = _holidayContext.GetFilterData(sortColumn, sortColumnDir, searchValue, null);

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
