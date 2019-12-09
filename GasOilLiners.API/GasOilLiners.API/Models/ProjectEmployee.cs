using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GasOilLiners.API.Models
{
    public partial class ProjectEmployee
    {
        public ProjectEmployee()
        {
            EmployeeAttendance = new HashSet<EmployeeAttendance>();
            EmployeeSalary = new HashSet<EmployeeSalary>();
            EmployeeSalaryAdvance = new HashSet<EmployeeSalaryAdvance>();
        }

        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        [StringLength(250)]
        public string Remarks { get; set; }
        public int Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        [Column("CreatedIP")]
        [StringLength(15)]
        public string CreatedIp { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [Column("ModifiedIP")]
        [StringLength(15)]
        public string ModifiedIp { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(EmployeeMaster.ProjectEmployee))]
        public virtual EmployeeMaster Employee { get; set; }
        [ForeignKey(nameof(ProjectId))]
        [InverseProperty(nameof(ProjectMaster.ProjectEmployee))]
        public virtual ProjectMaster Project { get; set; }
        [InverseProperty("ProjectEmployee")]
        public virtual ICollection<EmployeeAttendance> EmployeeAttendance { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<EmployeeSalary> EmployeeSalary { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<EmployeeSalaryAdvance> EmployeeSalaryAdvance { get; set; }
    }
}
