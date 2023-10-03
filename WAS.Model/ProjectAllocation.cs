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
    public class ProjectAllocation
    {
        [Key]
        public int ProjectAllocationId { get; set; }


        [Required(ErrorMessage = "Project number is required")]
        [Display(Name = "Project Number (PGT)")]
        public string PGTJobNumber { get; set; }

        [Required(ErrorMessage = "Client name is required")]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Project name is required")]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Client job number is required")]
        [Display(Name = "Client Job Number")]
        public string ClientJobNumber { get; set; }

        [Required]
        public double ProductionHours { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Planned Start Date")]
        public string? PlannedStartDt { get; set; }

        [Display(Name = "Planned End Date")]
        public string? PlannedEndDt { get; set; }

        [Display(Name = "Actual Start Date")]
        public string? ActualStartDt { get; set; }

        [Display(Name = "Actual End Date")]
        public string? ActualEndDt { get; set; }

        public double? PlannedBudget { get; set; }

        public string TimeStamp { get; set; } = DateTime.Now.ToString();


        public MainAllocation? MainAllocation { get; set; }
        public MiscAllocation? MiscAllocation { get; set; }
        public MainAndMiscAllocation? MainAndMiscAllocation { get; set; }


        public bool IsMainChecked { get; set; }
        public bool IsMiscChecked { get; set; }
        public bool IsMainMiscChecked { get; set; }
    }
}
