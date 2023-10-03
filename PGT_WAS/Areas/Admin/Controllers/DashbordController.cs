using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WAS.Utility;
using WAS.Interface;
using WAS.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace PGT_WAS.Areas.Admin.Controllers
{
    [Area(SD.ROLE.Role_Admin)]
    [Authorize(Roles = SD.ROLE.Role_Admin)]
    public class DashbordController : Controller
    {
        public IActionResult Dashbord()
        {
            return View();
        }
    }
}
