using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GasOilLiners.API.Models;
using GasOilLiners.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GasOilLiners.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly GasOilLinersContext _context;

        public SearchController(GasOilLinersContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<EmployeeAttendanceVM>>> Employee(SearchVM search)
        {
            List<EmployeeAttendanceVM> employeeAttendances = new List<EmployeeAttendanceVM>();
            var employees = await _context.ProjectEmployee.Where(x => x.ProjectId == search.Project).Include(y => y.Employee).ThenInclude(y=>y.CategoryNavigation).Include(y => y.EmployeeAttendance).ToListAsync();
            //return await _context.EmployeeMaster.ToListAsync();
            foreach (var emp in employees)
            {
                employeeAttendances.Add(new EmployeeAttendanceVM 
                { 
                    EmployeeCode = emp.Employee.EmployeeNumber,
                    EmployeeId = emp.Employee.Id,
                    EmployeeName = emp.Employee.Name,
                    StartDate = emp.Employee.StartDate,
                    Phone = emp.Employee.Phone,
                    Position = emp.Employee.CategoryNavigation.Category,
                    ProjectEmployeeId = emp.Id,
                    ProjectId = emp.ProjectId,
                    EmployeeAttendance = emp.EmployeeAttendance.Where(x => x.Date != DateTime.Today).TakeLast(7).Reverse().Select(x => new EmployeeAttendance 
                    {
                        Attendance = x.Attendance,
                        Date = x.Date                        
                    }).ToArray(),
                    Month1Count = emp.EmployeeAttendance.Where(x => x.Date.Month == (DateTime.Now.Month - 1) && x.Date.Year == DateTime.Now.Year).Count(),
                    Month2Count = emp.EmployeeAttendance.Where(x => x.Date.Month == (DateTime.Now.Month - 2) && x.Date.Year == DateTime.Now.Year).Count(),
                    Month3Count = emp.EmployeeAttendance.Where(x => x.Date.Month == (DateTime.Now.Month - 3) && x.Date.Year == DateTime.Now.Year).Count()

                });
            }
            return employeeAttendances;
        }

        public async Task<ActionResult<IEnumerable<EmployeeAttendance>>> Attendance(int empId, int month)
        {
            DateTime fromDate = new DateTime(DateTime.Now.Year, month, 1);
            DateTime toDate = new DateTime(DateTime.Now.Year, month, DateTime.DaysInMonth(DateTime.Now.Year,month));
            List<EmployeeAttendanceVM> employeeAttendances = new List<EmployeeAttendanceVM>();
            int projectEmployeeId = _context.ProjectEmployee.Where(x => x.EmployeeId == empId).Select(p => p.Id).FirstOrDefault();
            var employees = await _context.EmployeeAttendance.Where(x => x.ProjectEmployeeId == projectEmployeeId && x.Date >= fromDate && x.Date <= toDate)
                .Select(p=> new EmployeeAttendance 
                {
                    Attendance = p.Attendance,
                    CreatedBy = p.CreatedBy,
                    CreatedOn = p.CreatedOn,
                    Date = p.Date
                }).ToListAsync();
            employees.Reverse();
            return employees;
        }
        }
}
