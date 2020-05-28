using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practical.Model
{
    public class Employee
    {
        [Key]
        public int EmploeeId { get; set; }

        public string Name { get; set; }

        [ForeignKey("Club")]
        public char ClubId { get; set; }

        [ForeignKey("Department")]
        public char? DepartmentId { get; set; }

        public Department Department { get; set; }

        public Club Club { get; set; }
    }
}
