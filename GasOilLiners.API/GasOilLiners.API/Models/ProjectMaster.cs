using System;
using System.Collections.Generic;

namespace GasOilLiners.API.Models
{
    public partial class ProjectMaster
    {
        public ProjectMaster()
        {
            ProjectEmployee = new HashSet<ProjectEmployee>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public int ProjectCategory { get; set; }
        public string Remarks { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedIp { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string ModifiedIp { get; set; }

        public virtual ProjectCategoryMaster ProjectCategoryNavigation { get; set; }
        public virtual ICollection<ProjectEmployee> ProjectEmployee { get; set; }
    }
}
