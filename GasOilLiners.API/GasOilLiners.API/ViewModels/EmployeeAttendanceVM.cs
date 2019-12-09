using GasOilLiners.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasOilLiners.API.ViewModels
{
    public class EmployeeAttendanceVM
    {
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public int ProjectEmployeeId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public string Position { get; set; }
        public DateTime? StartDate { get; set; }

        public string Phone { get; set; }
        public EmployeeAttendance[] EmployeeAttendance;
        public int Month1Count { get; set; }
        public int Month2Count { get; set; }
        public int Month3Count { get; set; }


    }
}
