using System.Collections.Generic;
using System.Linq;
using GasOilLiners.API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GasOilLiners.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ProjectController : ControllerBase
    {

        private readonly ILogger<ProjectController> _logger;
        private readonly GasOilLinersContext _context;

        public ProjectController(ILogger<ProjectController> logger, GasOilLinersContext context)
        {
            _logger = logger;
            _context = context;
        }
        //Get the List of all projects
        [HttpGet]
        public ActionResult<IEnumerable<ProjectMaster>> Get()
        {
            return _context.ProjectMaster.Include(x=>x.ProjectEmployee).Include(y=>y.ProjectCategoryNavigation).ToList();
        }

        //Get Project by Id
        [HttpGet("{id}")]
        public ActionResult<ProjectMaster> Get(int id)
        {
            var project = _context.ProjectMaster.Find(id);
            if (project == null)
                return NotFound();
            return project;
        }

        //Add/Create/Post new project
        [HttpPost()]
        public ActionResult<IEnumerable<ProjectMaster>> Post(ProjectMaster projectMaster)
        {
            //Validate Model Fields
            //Check for Duplicate
            if (ModelState.IsValid)
            {
                _context.ProjectMaster.Add(projectMaster);
                _context.SaveChanges();
                return CreatedAtAction("Get", new { id = projectMaster.Id }, projectMaster);
            }
            else return BadRequest();

        }
    }
}