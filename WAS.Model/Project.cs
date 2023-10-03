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
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

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


        [Required(ErrorMessage = "Hours is required")]
        [Display(Name = "Main")]
        public double MainH { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public string? MainStartDt { get; set; }

        [Required(ErrorMessage = "Hours is required")]
        [Display(Name = "Misc")]
        public double MiscH { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Misc Start Date")]
        public string? MiscStartDate { get; set; }
   
        [Required(ErrorMessage = "Hours is required")]
        [Display(Name = "Total")]
        public double TotalH { get; set; }

        [Required(ErrorMessage = "Ratio required")]
        [Display(Name = "Ratio (IFF:IFA)")]
        public string Ratio { get; set; }

        [Required(ErrorMessage = "Schedule days required")]
        [Display(Name = "Schedule Days")]
        public int MainSDt { get; set; }

        [Required(ErrorMessage = "Schedule days required")]
        [Display(Name = "Schedule Days")]
        public int MiscSDt { get; set; }

        [Required(ErrorMessage = "Hours required")]
        [Display(Name = "Per day")]
        public double WHPerday { get; set; }

        [Range(0, 100, ErrorMessage = "Needs to be between 0-100")]
        [Required(ErrorMessage = "percent required")]
        public double MainModelersNdPercent { get; set; }

        [Range(0, 100, ErrorMessage = "Needs to be between 0-100")]
        [Required(ErrorMessage = "percent required")]
        public double MainDetilersNdPercent { get; set; }

        [Range(0, 100, ErrorMessage = "Needs to be between 0-100")]
        [Required(ErrorMessage = "percent required")]
        public double MainCheckersNdPercent { get; set; }

        [Range(0, 100, ErrorMessage = "Needs to be between 0-100")]
        [Required(ErrorMessage = "percent required")]
        public double MiscModelersNdPercent { get; set; }

        [Range(0, 100, ErrorMessage = "Needs to be between 0-100")]
        [Required(ErrorMessage = "percent required")]
        public double MiscDetilersNdPercent { get; set; }

        [Range(0, 100, ErrorMessage = "Needs to be between 0-100")]
        [Required(ErrorMessage = "percent required")]
        public double MiscCheckersNdPercent { get; set; }


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



        [ForeignKey("UserAccountEmployee")]
        public int UserAccountId { get; set; }

        [ForeignKey("UserAccountId")]
        public Employee UserAccountEmployee { get; set; }


        [ValidateNever]
        public virtual ProjectEstimation ProjectEstimation { get; set; }
    }
}
