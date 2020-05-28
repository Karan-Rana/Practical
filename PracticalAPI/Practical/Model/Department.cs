using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practical.Model
{
    public class Department
    {
        [Key]
        public char DepartmentId { get; set; }

        public string Name { get; set; }

        public Decimal AnnualBudget { get; set; }

        public ICollection<Employee> employees { get; set; }
    }
}
