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
    public class MiscAllocation
    {
        [Key]
        public int MiscAllocationId { get; set; }

        [Required(ErrorMessage = "Hours is required")]
        [Display(Name = "Misc")]
        public double Hours { get; set; }

        [Required(ErrorMessage = "Ratio required")]
        [Display(Name = "Ratio (IFF:IFA)")]
        public string Ratio { get; set; }

        [Required]
        public double R1 { get; set; }
        [Required]
        public double R2 { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }


        [Required(ErrorMessage = "Schedule days required")]
        [Display(Name = "Schedule Days")]
        public int ScheduleDays { get; set; }


        [Range(0, 100, ErrorMessage = "Needs to be between 0-100")]
        [Required(ErrorMessage = "percent required")]
        public double ModelerPercent { get; set; }

        [Range(0, 100, ErrorMessage = "Needs to be between 0-100")]
        [Required(ErrorMessage = "percent required")]
        public double DetailerPercent { get; set; }

        [Range(0, 100, ErrorMessage = "Needs to be between 0-100")]
        [Required(ErrorMessage = "percent required")]
        public double CheckerPercent { get; set; }

        public double IFA { get; set; }
        public double IFF { get; set; }


        public string SubmissionDate { get; set; }

        public double TotalResources { get; set; }

        public double TotalModeler { get; set; }
        public double TotalChecker { get; set; }
        public double TotalDetailer { get; set; }
        public double TotalCoordination { get; set; }

        [ForeignKey("ProjectAllocation")]
        public int? ProjectId { get; set; }

        [ForeignKey("ProjectAllocationId")]
        public ProjectAllocation? ProjectAllocation { get; set; }
    }
}
