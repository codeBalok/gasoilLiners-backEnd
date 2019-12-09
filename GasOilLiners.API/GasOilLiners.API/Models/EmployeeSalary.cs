using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GasOilLiners.API.Models
{
    public partial class EmployeeSalary
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal BaseSalary { get; set; }
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
        [InverseProperty(nameof(ProjectEmployee.EmployeeSalary))]
        public virtual ProjectEmployee Employee { get; set; }
    }
}
