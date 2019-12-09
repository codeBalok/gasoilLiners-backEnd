using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GasOilLiners.API.Models;

namespace GasOilLiners.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCategoryMastersController : ControllerBase
    {
        private readonly GasOilLinersContext _context;

        public ProjectCategoryMastersController(GasOilLinersContext context)
        {
            _context = context;
        }

        // GET: api/ProjectCategoryMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectCategoryMaster>>> GetProjectCategoryMaster()
        {
            return await _context.ProjectCategoryMaster.ToListAsync();
        }

        // GET: api/ProjectCategoryMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectCategoryMaster>> GetProjectCategoryMaster(int id)
        {
            var projectCategoryMaster = await _context.ProjectCategoryMaster.FindAsync(id);

            if (projectCategoryMaster == null)
            {
                return NotFound();
            }

            return projectCategoryMaster;
        }

        // PUT: api/ProjectCategoryMasters/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectCategoryMaster(int id, ProjectCategoryMaster projectCategoryMaster)
        {
            if (id != projectCategoryMaster.Id)
            {
                return BadRequest();
            }

            //_context.Entry(projectCategoryMaster).State = EntityState.Modified;

            projectCategoryMaster.ModifiedIp = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            projectCategoryMaster.ModifiedOn = DateTime.Now;
            _context.Attach(projectCategoryMaster);
            _context.Entry(projectCategoryMaster).Property("Name").IsModified = true;
            _context.Entry(projectCategoryMaster).Property("Description").IsModified = true;
            _context.Entry(projectCategoryMaster).Property("Status").IsModified = true;
            _context.Entry(projectCategoryMaster).Property("ModifiedIp").IsModified = true;
            _context.Entry(projectCategoryMaster).Property("ModifiedOn").IsModified = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectCategoryMasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProjectCategoryMasters
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ProjectCategoryMaster>> PostProjectCategoryMaster(ProjectCategoryMaster projectCategoryMaster)
        {
            projectCategoryMaster.CreatedIp = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            _context.ProjectCategoryMaster.Add(projectCategoryMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectCategoryMaster", new { id = projectCategoryMaster.Id }, projectCategoryMaster);
        }

        // DELETE: api/ProjectCategoryMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectCategoryMaster>> DeleteProjectCategoryMaster(int id)
        {
            var projectCategoryMaster = await _context.ProjectCategoryMaster.FindAsync(id);
            if (projectCategoryMaster == null)
            {
                return NotFound();
            }

            _context.ProjectCategoryMaster.Remove(projectCategoryMaster);
            await _context.SaveChangesAsync();

            return projectCategoryMaster;
        }

        private bool ProjectCategoryMasterExists(int id)
        {
            return _context.ProjectCategoryMaster.Any(e => e.Id == id);
        }
    }
}
