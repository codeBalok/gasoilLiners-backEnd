using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasOilLiners.API.ViewModels
{
    public class EmployeeCategoryVM
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int EmployeeCount { get; set; }

    }
}
