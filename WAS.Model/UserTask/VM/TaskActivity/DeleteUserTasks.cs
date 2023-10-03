using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAS.Model;


namespace WAS.Model
{
    public class DeleteUserTasks_VM
    {      
        [Required(ErrorMessage = "At lease select one tasks")]
        public int[] UserTaskIds { get; set; }
    }
}
