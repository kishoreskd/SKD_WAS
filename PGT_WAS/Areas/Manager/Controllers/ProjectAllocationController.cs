using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WAS.Utility;
using WAS.Interface;
using WAS.Model;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace PGT_WAS.Areas.Manager.Controllers
{
    [Authorize(Roles = SD.ROLE.Role_Manager)]
    [Area(SD.ROLE.Role_Manager)]
    public class ProjectAllocationController : Controller
    {
        private int _userId;
        private readonly ILogger<ProjectAllocationController> _logger;
        private readonly IUnitOfWork _unitWork;
        private string _includeEntities;
        public ProjectAllocationController(IUnitOfWork unitOfWork, ILogger<ProjectAllocationController> logger)
        {
            this._unitWork = unitOfWork;
            this._logger = logger;
            _includeEntities = $"{nameof(MainAndMiscAllocation)},{nameof(MiscAllocation)},{nameof(MainAllocation)}";
        }

        public async Task<IActionResult> Allocation()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpSert(int? id)
        {

            try
            {
                ProjectAllocation projectAllocation = new ProjectAllocation() { MainAllocation = new MainAllocation(), MiscAllocation = new MiscAllocation(), MainAndMiscAllocation = new MainAndMiscAllocation() };

                if (COM.IsValidID(id)) projectAllocation = await _unitWork.ProjectAllocation.GetFirstOrDefault(pa => id == pa.ProjectAllocationId,
                                                                  includeProp: _includeEntities);

                return View(projectAllocation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpSert(ProjectAllocation projectAllocation)
        {
            try
            {
                _userId = Convert.ToInt32(HttpContext.Session.GetString("user_id"));
                //projectAllocation.UserAccountId = _userId;

                if (!ModelState.IsValid)
                {
                    return View(projectAllocation);
                }

                ProjectAllocation projectDb = await _unitWork.ProjectAllocation.GetFirstOrDefault(proj => projectAllocation.ProjectAllocationId == proj.ProjectAllocationId,
                                                     includeProp: _includeEntities);

                SD.Msg = "Project saved successfully";

                if (COM.IsNull(projectDb))
                {
                    await _unitWork.ProjectAllocation.Add(projectAllocation);
                }
                else
                {
                    SD.Msg = "Project updated successfully";
                    _unitWork.ProjectAllocation.Update(projectAllocation);
                }

                await _unitWork.ProjectAllocation.Commit();
                TempData[SD.Success] = SD.Msg;
                return RedirectToAction(nameof(Allocation), "Allocation");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.InnerException.Message.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                ProjectAllocation project = await _unitWork.ProjectAllocation.GetFirstOrDefault(proj => proj.ProjectAllocationId == id,
                                                  includeProp: _includeEntities);

                if (COM.IsNull(project))
                {
                    return Json(new { success = false, msg = "Error while deleting" });
                }

                _unitWork.ProjectAllocation.Remove(project);
                await _unitWork.ProjectAllocation.Commit();

                return Json(new { success = true, msg = "Project deleted successfully !" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Json(new { success = false, msg = "Error code 500 Internal error...." });
            }
        }


        [HttpPost]
        public JsonResult GetAllProjectAllocation()
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

                //var v = _projectContext.GetFilterData(sortColumn, sortColumnDir, searchValue, "PGTJobNumber", "ProjectEstimation");
                var v = _unitWork.ProjectAllocation.GetFilterData(null, null, null, "PGTJobNumber", includeProp: _includeEntities);

                recordsTotal = v.Count();

                var data = v;

                if (length != null)
                {
                    data = v.Skip(skip).Take(pageSize).ToList();
                }

                JsonResult j = Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

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
