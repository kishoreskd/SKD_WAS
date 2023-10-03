﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
    public class UpdateUserTasks_VM
    {
        public int? ProjectId { get; set; }      

        [Required(ErrorMessage = "Start date required.")]
        public string StartDate { get; set; }

        [Required(ErrorMessage = "End date required.")]
        public string EndDate { get; set; }

        public string? Desctiption { get; set; }

        public int? Status { get; set; }

        [Required(ErrorMessage = "At lease select one tasks")]
        public int[] UserTaskIds { get; set; }
    }
}