using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GasOilLiners.API.Models
{
    public partial class EmployeeMaster
    {
        public EmployeeMaster()
        {
            ProjectEmployee = new HashSet<ProjectEmployee>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string EmployeeNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int? Age { get; set; }
        [StringLength(250)]
        public string Address { get; set; }
        [StringLength(50)]
        public string Position { get; set; }
        public int Category { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        [StringLength(15)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
        [StringLength(10)]
        public string Experience { get; set; }
        [StringLength(250)]
        public string Notes { get; set; }
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

        [ForeignKey(nameof(Category))]
        [InverseProperty(nameof(EmployeeCategoryMaster.EmployeeMaster))]
        public virtual EmployeeCategoryMaster CategoryNavigation { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<ProjectEmployee> ProjectEmployee { get; set; }
    }
}
