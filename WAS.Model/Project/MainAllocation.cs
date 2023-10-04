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
    public class MainAllocation
    {
        [Key]
        public int MainAllocationId { get; set; }

        [Display(Name = "Main")]
        public double Hours { get; set; }

      
        [Required]
        public double R1 { get; set; }

        [Required]
        public double R2 { get; set; }


        [Display(Name = "Start Date")]
        public string? StartDate { get; set; }


        [Display(Name = "Schedule Days")]
        public int ScheduleDays { get; set; }


        [Range(0, 100, ErrorMessage = "Needs to be between 0-100")]
        public double ModelerPercent { get; set; }

        [Range(0, 100, ErrorMessage = "Needs to be between 0-100")]
        public double CheckerPercent { get; set; }

        [Range(0, 100, ErrorMessage = "Needs to be between 0-100")]
        public double DetailerPercent { get; set; }


        public double IFA { get; set; }
        public double IFF { get; set; }

        public string SubmissionDate { get; set; }
        public double TotalResources { get; set; }

        public double TotalModeler { get; set; }
        public double TotalChecker { get; set; }
        public double TotalDetailer { get; set; }
        public double TotalCoordination { get; set; }

        public double Ratio1 { get; set; }
        public double Ratio2 { get; set; }


        [ForeignKey("ProjectAllocation")]
        public int? ProjectAllocationId { get; set; }

        [ForeignKey("ProjectAllocationId")]
        public ProjectAllocation? ProjectAllocation { get; set; }
    }
}
