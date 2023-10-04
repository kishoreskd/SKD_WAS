using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using WAS.Model;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WAS.Model
{
    public class UserTasks
    {
        [Key]
        public int UserTasksId { get; set; }

        [Required]
        [ValidateNever]
        public string Month { get; set; }

        [Required(ErrorMessage = "Please add start date")]
        public string StartDate { get; set; }

        [Required(ErrorMessage = "Please add end date")]
        public string EndDate { get; set; }

        public string TimeStamp { get; set; } = DateTime.Now.ToString();

        public int? Status { get; set; }

        public string? Description { get; set; }

        [ForeignKey("Id")]
        [Required]
        [ValidateNever]
        public int EmployeeId { get; set; }

        [ValidateNever]
        public Employee Employee { get; set; }


        [ForeignKey("ProjectAllocation")]
        public int? ProjectAllocationId { get; set; }

        [ValidateNever]
        [ForeignKey("ProjectAllocationId")]
        public ProjectAllocation? ProjectAllocation { get; set; }


        [ForeignKey("UserAccountEmployee")]
        public int UserAccountId { get; set; }

        [ForeignKey("UserAccountId")]
        public Employee UserAccountEmployee { get; set; }



        [ForeignKey("UserTaskStatus")]
        public int? UserTaskStatusId { get; set; }

        [ForeignKey("UserTaskStatusId")]
        public UserTaskStatus UserTaskStatus { get; set; }
    }
}
