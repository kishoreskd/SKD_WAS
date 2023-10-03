using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WAS.Model
{
    public class Holiday
    {
        [Key]
        public int HolidayId { get; set; }

        [Required]
        [Display(Name = "Holiday name")]
        public string HolidayName { get; set; }

        [Required]
        [Display(Name = "Holiday date")]
        public string HolidayDate { get; set; }

        [Display(Name = "Description")]
        [ValidateNever]
        public string? Remarks { get; set; }
    }
}
