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
    public class UserTaskStatus
    {
        [Key]
        public int UserTaskStatusId { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
