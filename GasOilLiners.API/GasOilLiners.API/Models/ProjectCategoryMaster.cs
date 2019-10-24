using System;
using System.Collections.Generic;

namespace GasOilLiners.API.Models
{
    public partial class ProjectCategoryMaster
    {
        public ProjectCategoryMaster()
        {
            ProjectMaster = new HashSet<ProjectMaster>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedIp { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string ModifiedIp { get; set; }

        public virtual ICollection<ProjectMaster> ProjectMaster { get; set; }
    }
}
