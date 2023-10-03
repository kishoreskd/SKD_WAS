using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WAS.Model
{
    public class Designation
    {
        [Key]
        public int DesignationId { get; set; }

        [Required]
        [Display(Name = "Designation name")]
        public string DesignationName { get; set; }

        [Required(ErrorMessage = "Select any ones of the one department")]
        public int DepartmentId { get; set; }

        [NotMapped]
        [ValidateNever]
        public Department Department { get; set; }
    }
}
