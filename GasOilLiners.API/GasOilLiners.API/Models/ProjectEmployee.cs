using System;
using System.Collections.Generic;

namespace GasOilLiners.API.Models
{
    public partial class ProjectEmployee
    {
        public ProjectEmployee()
        {
            EmployeeSalary = new HashSet<EmployeeSalary>();
        }

        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Remarks { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedIp { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string ModifiedIp { get; set; }

        public virtual EmployeeMaster Employee { get; set; }
        public virtual ProjectMaster Project { get; set; }
        public virtual ICollection<EmployeeSalary> EmployeeSalary { get; set; }
    }
}
