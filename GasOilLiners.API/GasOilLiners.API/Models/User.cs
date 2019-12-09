using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GasOilLiners.API.Models
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public byte[] Photo { get; set; }

        [StringLength(250)]
        public string Remarks { get; set; }
        public int Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }

        [Column("CreatedIP")]
        [StringLength(15)]
        public string CreatedIp { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        [Column("ModifiedIP")]
        [StringLength(15)]
        public string ModifiedIp { get; set; }
    }
}
