using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GasOilLiners.API.Models;
using GasOilLiners.API.ViewModels;

namespace GasOilLiners.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly GasOilLinersContext _context;

        public EmployeeController(GasOilLinersContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeMaster>>> GetEmployeeMaster()
        {
            //return await _context.EmployeeMaster.Join(
            //    _context.EmployeeCategoryMaster, 
            //    emp => emp.Category,

            //    ).ToListAsync();
            return await _context.EmployeeMaster.Include( x=> x.CategoryNavigation).Include(y => y.ProjectEmployee).ThenInclude(y => y.Project).ToListAsync();
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeMaster>> GetEmployeeMaster(int id)
        {
            var employeeMaster = await _context.EmployeeMaster.Include(x => x.CategoryNavigation).Include(y => y.ProjectEmployee).ThenInclude(y => y.Project).Where(x=>x.Id == id).FirstAsync();

            if (employeeMaster == null)
            {
                return NotFound();
            }

            return employeeMaster;
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeMaster(int id, EmployeeMaster employeeMaster)
        {
            if (id != employeeMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeMasterExists(id))
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

        // POST: api/Employee
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EmployeeMaster>> PostEmployeeMaster(EmployeeInfoVM employeeInfo)
        {
            EmployeeMaster employeeMaster = new EmployeeMaster
            {
                Address = employeeInfo.Address,
                Age = employeeInfo.Age,
                Category = employeeInfo.CategoryId,
                CreatedBy = employeeInfo.CreatedBy,
                CreatedIp = "0.0.0.1",
                CreatedOn = new DateTime(),
                DateOfBirth = employeeInfo.DateOfBirth,
                Email = employeeInfo.Email,
                EmployeeNumber = employeeInfo.EmployeeNumber,
                EndDate = employeeInfo.EndDate,
                Experience = employeeInfo.Experience,
                Name = employeeInfo.Name,
                Notes = employeeInfo.Notes,
                Phone = employeeInfo.Phone,
                StartDate = employeeInfo.StartDate

            };
            _context.EmployeeMaster.Add(employeeMaster);
            await _context.SaveChangesAsync();
            ProjectEmployee projectEmployee = new ProjectEmployee
            {
                CreatedBy = employeeInfo.CreatedBy,
                CreatedOn = new DateTime(),
                CreatedIp = "0.0.0.1",
                EmployeeId = employeeMaster.Id,
                ProjectId = employeeInfo.ProjectId,
                StartDate = employeeInfo.StartDate,
                EndDate = employeeInfo.EndDate
            };
            _context.ProjectEmployee.Add(projectEmployee);
            await _context.SaveChangesAsync();
            EmployeeSalary employeeSalary = new EmployeeSalary
            {
                CreatedBy = employeeInfo.CreatedBy,
                CreatedOn = new DateTime(),
                CreatedIp = "0.0.0.1",
                EmployeeId = projectEmployee.Id,
                BaseSalary = Convert.ToDecimal(employeeInfo.Salary)
            };
            _context.EmployeeSalary.Add(employeeSalary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeMaster", new { id = employeeMaster.Id }, employeeMaster);
            //return BadRequest();
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeMaster>> DeleteEmployeeMaster(int id)
        {
            var employeeMaster = await _context.EmployeeMaster.FindAsync(id);
            if (employeeMaster == null)
            {
                return NotFound();
            }

            _context.EmployeeMaster.Remove(employeeMaster);
            await _context.SaveChangesAsync();

            return employeeMaster;
        }

        private bool EmployeeMasterExists(int id)
        {
            return _context.EmployeeMaster.Any(e => e.Id == id);
        }
    }
}
