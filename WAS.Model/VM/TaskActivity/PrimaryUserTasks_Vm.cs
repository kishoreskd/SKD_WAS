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
    public class PrimaryuserTasks
    {
        public PostUserTasks_VM PostUserTasks_VM { get; set; } = new PostUserTasks_VM();
        public UpdateUserTasks_VM UpdateUserTasks_VM { get; set; } = new UpdateUserTasks_VM();
        public DeleteUserTasks_VM DeleteUserTasks_VM { get; set; } = new DeleteUserTasks_VM();

    }
}
