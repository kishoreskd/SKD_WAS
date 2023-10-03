using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WAS.Model
{
    [NotMapped]
    public class Project_VM
    {

        [Key]
        [Column(name: "Id")]
        public int ProjectId { get; set; }

        [Required]
        [Display(Name = "Project Number (PGT)")]

        public string PGTJobNumber { get; set; }

        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Client Job Number")]
        public string ClientJobNumber { get; set; }


        [Display(Name = "Main")]
        public double MainH { get; set; }

        [Display(Name = "Main Start Date")]
        public string MainStartDt { get; set; }

        [Display(Name = "Misc")]
        public double MiscH { get; set; }

        [Display(Name = "Misc Start Date")]
        public string MiscStartDate { get; set; }

        [Display(Name = "Connection")]
        public double ConnectionH { get; set; }

        [Display(Name = "Stair")]
        public double StairH { get; set; }

        [Display(Name = "Total")]
        public double TotalH { get; set; }

        [Display(Name = "Ratio (IFF:IFA)")]
        public string Ratio { get; set; }

        [Display(Name = "Main Schedule Days (IFA)")]
        public int MainSDt { get; set; }

        [Display(Name = "Misc Schedule Days (IFA)")]
        public int MiscSDt { get; set; }

        [Display(Name = "Per day")]
        public double WHPerday { get; set; }


        public double MainModelersNdPercent { get; set; }
        public double MainDetilersNdPercent { get; set; }
        public double MainCheckersNdPercent { get; set; }


        public double MiscModelersNdPercent { get; set; }
        public double MiscDetilersNdPercent { get; set; }
        public double MiscCheckersNdPercent { get; set; }


        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Planned Start Date")]
        public string PlannedStartDt { get; set; }

        [Display(Name = "Planned End Date")]
        public string PlannedEndDt { get; set; }

        [Display(Name = "Actual Start Date")]
        public string ActualStartDt { get; set; }

        [Display(Name = "Actual End Date")]
        public string ActualEndDt { get; set; }

        public double PlannedBudget { get; set; }

        public string TimeStamp { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");

        public int ProjectEstimationId { get; set; }

        [ValidateNever]
        [ForeignKey("ProjectEstimationId")]
        public virtual ProjectEstimation ProjectEstimation { get; set; }
    }
}
