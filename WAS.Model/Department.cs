using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAS.Model
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [Display(Name = "Department name")]
        public string DepartmentName { get; set; }

    }
}
