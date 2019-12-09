using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GasOilLiners.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GasOilLiners.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly GasOilLinersContext _context;

        public DashboardController(GasOilLinersContext context)
        {
            _context = context;
        }
        
        // GET: api/Dashboard
        [HttpGet]
        public ActionResult<dynamic> GetDashboard()
        {
            return new { ProjectCount = _context.ProjectMaster.Count(), EmployeeCount = _context.EmployeeMaster.Count() };
        }

    }
}