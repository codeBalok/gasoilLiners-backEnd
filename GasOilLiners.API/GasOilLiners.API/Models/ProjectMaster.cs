using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GasOilLiners.API.Models
{
    public partial class ProjectMaster
    {
        public ProjectMaster()
        {
            ProjectEmployee = new HashSet<ProjectEmployee>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Code { get; set; }
        [Required]
        [StringLength(1000)]
        public string Title { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        [Required]
        [StringLength(50)]
        public string Location { get; set; }
        public int ProjectCategory { get; set; }
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

        [ForeignKey(nameof(ProjectCategory))]
        [InverseProperty(nameof(ProjectCategoryMaster.ProjectMaster))]
        public virtual ProjectCategoryMaster ProjectCategoryNavigation { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<ProjectEmployee> ProjectEmployee { get; set; }
    }
}
