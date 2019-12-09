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
    public class EmployeeSalaryAdvancesController : ControllerBase
    {
        private readonly GasOilLinersContext _context;

        public EmployeeSalaryAdvancesController(GasOilLinersContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeSalaryAdvances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeSalaryAdvance>>> GetEmployeeSalaryAdvance()
        {
            return await _context.EmployeeSalaryAdvance.ToListAsync();
        }

        // GET: api/EmployeeSalaryAdvances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeSalaryAdvance>> GetEmployeeSalaryAdvance(int id)
        {
            var employeeSalaryAdvance = await _context.EmployeeSalaryAdvance.FindAsync(id);

            if (employeeSalaryAdvance == null)
            {
                return NotFound();
            }

            return employeeSalaryAdvance;
        }

        // PUT: api/EmployeeSalaryAdvances/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeSalaryAdvance(int id, EmployeeSalaryAdvance employeeSalaryAdvance)
        {
            if (id != employeeSalaryAdvance.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeSalaryAdvance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeSalaryAdvanceExists(id))
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

        // POST: api/EmployeeSalaryAdvances
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EmployeeSalaryAdvance>> PostEmployeeSalaryAdvance(EmployeeSalaryAdvance employeeSalaryAdvance)
        {
            _context.EmployeeSalaryAdvance.Add(employeeSalaryAdvance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeSalaryAdvance", new { id = employeeSalaryAdvance.Id }, employeeSalaryAdvance);
        }

        // DELETE: api/EmployeeSalaryAdvances/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeSalaryAdvance>> DeleteEmployeeSalaryAdvance(int id)
        {
            var employeeSalaryAdvance = await _context.EmployeeSalaryAdvance.FindAsync(id);
            if (employeeSalaryAdvance == null)
            {
                return NotFound();
            }

            _context.EmployeeSalaryAdvance.Remove(employeeSalaryAdvance);
            await _context.SaveChangesAsync();

            return employeeSalaryAdvance;
        }

        private bool EmployeeSalaryAdvanceExists(int id)
        {
            return _context.EmployeeSalaryAdvance.Any(e => e.Id == id);
        }
    }
}
