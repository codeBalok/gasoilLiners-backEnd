using GasOilLiners.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasOilLiners.API.ViewModels
{
    public class EmployeeInfoVM
    {
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Experience { get; set; }
        public string Notes { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedIP { get; set; }
        public int CreatedBy { get; set; }
        public int ProjectId { get; set; }
        public string Salary { get; set; }

    }
}
