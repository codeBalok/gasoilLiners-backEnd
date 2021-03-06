﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GasOilLiners.API.Models
{
    public partial class EmployeeCategoryMaster
    {
        public EmployeeCategoryMaster()
        {
            EmployeeMaster = new HashSet<EmployeeMaster>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Category { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
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

        [InverseProperty("CategoryNavigation")]
        public virtual ICollection<EmployeeMaster> EmployeeMaster { get; set; }
    }
}
