using System;
using System.Collections.Generic;

namespace GasOilLiners.API.Models
{
    public partial class EmployeeCategoryMaster
    {
        public EmployeeCategoryMaster()
        {
            EmployeeMaster = new HashSet<EmployeeMaster>();
        }

        public int Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedIp { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string ModifiedIp { get; set; }

        public virtual ICollection<EmployeeMaster> EmployeeMaster { get; set; }
    }
}
