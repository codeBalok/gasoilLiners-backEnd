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
    public class EmployeeCategoryController : ControllerBase
    {
        private readonly GasOilLinersContext _context;

        public EmployeeCategoryController(GasOilLinersContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeCategoryMaster>>> GetEmployeeCategoryMaster()
        {
            return await _context.EmployeeCategoryMaster.ToListAsync();
        }

        // GET: api/EmployeeCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeCategoryMaster>> GetEmployeeCategoryMaster(int id)
        {
            var employeeCategoryMaster = await _context.EmployeeCategoryMaster.FindAsync(id);

            if (employeeCategoryMaster == null)
            {
                return NotFound();
            }

            return employeeCategoryMaster;
        }

        // PUT: api/EmployeeCategory/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeCategoryMaster(int id, EmployeeCategoryMaster employeeCategoryMaster)
        {
            if (id != employeeCategoryMaster.Id)
            {
                return BadRequest();
            }

            //_context.Entry(employeeCategoryMaster).State = EntityState.Modified;

            employeeCategoryMaster.ModifiedIp = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            employeeCategoryMaster.ModifiedOn = DateTime.Now;
            _context.Attach(employeeCategoryMaster);
            _context.Entry(employeeCategoryMaster).Property("Category").IsModified = true;
            _context.Entry(employeeCategoryMaster).Property("Description").IsModified = true;
            _context.Entry(employeeCategoryMaster).Property("Status").IsModified = true;
            _context.Entry(employeeCategoryMaster).Property("ModifiedIp").IsModified = true;
            _context.Entry(employeeCategoryMaster).Property("ModifiedOn").IsModified = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeCategoryMasterExists(id))
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

        // POST: api/EmployeeCategory
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EmployeeCategoryMaster>> PostEmployeeCategoryMaster(EmployeeCategoryMaster employeeCategoryMaster)
        {
            employeeCategoryMaster.CreatedIp = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            _context.EmployeeCategoryMaster.Add(employeeCategoryMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeCategoryMaster", new { id = employeeCategoryMaster.Id }, employeeCategoryMaster);
        }

        // DELETE: api/EmployeeCategory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeCategoryMaster>> DeleteEmployeeCategoryMaster(int id)
        {
            var employeeCategoryMaster = await _context.EmployeeCategoryMaster.FindAsync(id);
            if (employeeCategoryMaster == null)
            {
                return NotFound();
            }

            _context.EmployeeCategoryMaster.Remove(employeeCategoryMaster);
            await _context.SaveChangesAsync();

            return employeeCategoryMaster;
        }

        private bool EmployeeCategoryMasterExists(int id)
        {
            return _context.EmployeeCategoryMaster.Any(e => e.Id == id);
        }
    }
}
