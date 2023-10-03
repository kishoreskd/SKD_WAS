using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAS.Utility;

namespace PGT_WAS.Areas.Manager.Controllers
{
    [Authorize(Roles = SD.ROLE.Role_Manager)]
    [Area(SD.ROLE.Role_Manager)]
    public class AllocationSheetController : Controller
    {
        public IActionResult AllocationSheet()
        {
            return View();
        }
    }
}
