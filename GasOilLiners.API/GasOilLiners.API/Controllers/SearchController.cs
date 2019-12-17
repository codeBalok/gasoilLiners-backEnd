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
        public async Task<ActionResult<dynamic>> Employee(SearchVM search)
        {
            List<EmployeeAttendanceVM> employeeAttendances = new List<EmployeeAttendanceVM>();
            var employees = await _context.ProjectEmployee.Where(x => x.ProjectId == search.Project).Include(y => y.Employee).ThenInclude(y => y.CategoryNavigation).Include(y => y.EmployeeAttendance).ToListAsync();

            DateTime[] last7Days = Enumerable.Range(1, 7).Select(i => DateTime.Now.Date.AddDays(-i)).ToArray();

            foreach (var emp in employees)
            {
                EmployeeAttendanceVM _empAttendance = new EmployeeAttendanceVM()
                {
                    EmployeeCode = emp.Employee.EmployeeNumber,
                    EmployeeId = emp.Employee.Id,
                    EmployeeName = emp.Employee.Name,
                    StartDate = emp.Employee.StartDate,
                    Phone = emp.Employee.Phone,
                    Position = emp.Employee.CategoryNavigation.Category,
                    ProjectEmployeeId = emp.Id,
                    ProjectId = emp.ProjectId,
                    //EmployeeAttendance = emp.EmployeeAttendance.Where(x => last7Days.Contains(x.Date)).Select(x => new EmployeeAttendance
                    //{
                    //    Attendance = x.Attendance ,
                    //    Date = x.Date
                    //}).ToArray(),
                    TodayAttendance = emp.EmployeeAttendance.Where(x => x.Date.Date == DateTime.Now.Date).Select(p=> p.Attendance).FirstOrDefault(),
                    Month1Count = emp.EmployeeAttendance.Where(x => x.Date.Month == (DateTime.Now.Month - 1) && x.Date.Year == DateTime.Now.Year).Count(),
                    Month2Count = emp.EmployeeAttendance.Where(x => x.Date.Month == (DateTime.Now.Month - 2) && x.Date.Year == DateTime.Now.Year).Count(),
                    Month3Count = emp.EmployeeAttendance.Where(x => x.Date.Month == (DateTime.Now.Month - 3) && x.Date.Year == DateTime.Now.Year).Count()

                };
                List<EmployeeAttendance> _attendanceList = new List<EmployeeAttendance>(); ;
                foreach (DateTime d in last7Days)
                {
                    string _attendance = emp.EmployeeAttendance.Where(x => x.Date.Date == d.Date).Select(p => p.Attendance).FirstOrDefault();
                    _attendanceList.Add(new EmployeeAttendance()
                    {
                        Attendance = string.IsNullOrWhiteSpace(_attendance) ? "-" : _attendance
                    });
                }
                _attendanceList.Reverse();
                _empAttendance.EmployeeAttendance = _attendanceList.ToArray();
                employeeAttendances.Add(_empAttendance);
            }

            // check todays attendance done 
            var todayAttendance = await _context.EmployeeAttendance.Where(p => p.Date.Date == DateTime.Now.Date && p.ProjectEmployee.ProjectId == search.Project).ToListAsync();
            return new
            {
                Attendance = employeeAttendances,
                AttendanceDone = todayAttendance.Count()
            };
        }

        public async Task<ActionResult<IEnumerable<EmployeeAttendance>>> Attendance(int empId, int month)
        {
            DateTime fromDate = new DateTime(DateTime.Now.Year, month, 1);
            DateTime toDate = new DateTime(DateTime.Now.Year, month, DateTime.DaysInMonth(DateTime.Now.Year, month));
            List<EmployeeAttendanceVM> employeeAttendances = new List<EmployeeAttendanceVM>();
            int projectEmployeeId = _context.ProjectEmployee.Where(x => x.EmployeeId == empId).Select(p => p.Id).FirstOrDefault();
            var employees = await _context.EmployeeAttendance.Where(x => x.ProjectEmployeeId == projectEmployeeId && x.Date >= fromDate && x.Date <= toDate)
                .Select(p => new EmployeeAttendance
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
