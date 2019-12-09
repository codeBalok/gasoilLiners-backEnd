using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GasOilLiners.API.Models
{
    public partial class ProjectCategoryMaster
    {
        public ProjectCategoryMaster()
        {
            ProjectMaster = new HashSet<ProjectMaster>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [StringLength(100)]
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

        [InverseProperty("ProjectCategoryNavigation")]
        public virtual ICollection<ProjectMaster> ProjectMaster { get; set; }
    }
}
