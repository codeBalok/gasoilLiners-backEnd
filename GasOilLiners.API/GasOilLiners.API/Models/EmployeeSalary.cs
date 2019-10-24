using System;
using System.Collections.Generic;

namespace GasOilLiners.API.Models
{
    public partial class EmployeeSalary
    {
        public int Id { get; set; }
        public int ProjectEmployeeId { get; set; }
        public decimal BaseSalary { get; set; }
        public string Remarks { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedIp { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string ModifiedIp { get; set; }

        public virtual ProjectEmployee ProjectEmployee { get; set; }
    }
}
