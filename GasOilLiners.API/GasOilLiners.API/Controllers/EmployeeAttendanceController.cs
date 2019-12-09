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
    public class EmployeeAttendanceController : ControllerBase
    {
        private readonly GasOilLinersContext _context;

        public EmployeeAttendanceController(GasOilLinersContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeAttendance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeAttendance>>> GetEmployeeAttendance()
        {
            return await _context.EmployeeAttendance.ToListAsync();
        }

        // GET: api/EmployeeAttendance/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeAttendance>> GetEmployeeAttendance(int id)
        {
            var employeeAttendance = await _context.EmployeeAttendance.FindAsync(id);

            if (employeeAttendance == null)
            {
                return NotFound();
            }

            return employeeAttendance;
        }

        // PUT: api/EmployeeAttendance/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeAttendance(int id, EmployeeAttendance employeeAttendance)
        {
            if (id != employeeAttendance.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeAttendance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeAttendanceExists(id))
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

        // POST: api/EmployeeAttendance
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<int>> PostEmployeeAttendance(EmployeeAttendance[] employeeAttendances)
        {
            _context.EmployeeAttendance.AddRange(employeeAttendances);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetEmployeeAttendance", new { id = employeeAttendance.Id }, employeeAttendance);
            return employeeAttendances.Length;
        }

        // DELETE: api/EmployeeAttendance/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeAttendance>> DeleteEmployeeAttendance(int id)
        {
            var employeeAttendance = await _context.EmployeeAttendance.FindAsync(id);
            if (employeeAttendance == null)
            {
                return NotFound();
            }

            _context.EmployeeAttendance.Remove(employeeAttendance);
            await _context.SaveChangesAsync();

            return employeeAttendance;
        }

        private bool EmployeeAttendanceExists(int id)
        {
            return _context.EmployeeAttendance.Any(e => e.Id == id);
        }
        
    }
}
