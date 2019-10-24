using System;
using System.Collections.Generic;

namespace GasOilLiners.API.Models
{
    public partial class EmployeeMaster
    {
        public EmployeeMaster()
        {
            ProjectEmployee = new HashSet<ProjectEmployee>();
        }

        public int Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public int Category { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Experience { get; set; }
        public string Notes { get; set; }
        public string Remarks { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedIp { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string ModifiedIp { get; set; }

        public virtual EmployeeCategoryMaster CategoryNavigation { get; set; }
        public virtual ICollection<ProjectEmployee> ProjectEmployee { get; set; }
    }
}
