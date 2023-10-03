using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WAS.Model;

namespace WAS.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        public string DOB { get; set; }

        [Required]
        [Display(Name = "Date of joining")]
        public string DateOfJoining
        {
            get; set;
        }

        [MaxLength(4)]
        [Required]
        [Display(Name = "Employee id")]
        public string EmployeeId { get; set; }


        [Required(ErrorMessage = "Enter valid email id")]
        [Display(Name = "Email id")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string EmailID { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int Gender { get; set; }

        [Required(ErrorMessage = "Mobile number required")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile number")]
        [Display(Name = "Mobile number")]
        public string MobileNumber { get; set; }

        [Required]
        [Display(Name = "Blood group")]
        public string BloodGroup { get; set; }

        [Required]
        [Display(Name = "Total years of experiance")]
        public int TotalExperiance { get; set; }


        [Display(Name = "Experiance in this department")]
        [ValidateNever]
        public string? ExperianceInThisDep { get; set; }

        [Display(Name = "Types of job handles in this department")]
        [ValidateNever]
        public string? TypesOfJobHandle { get; set; }


        [Required(ErrorMessage = "Username required")]
        [Compare("EmployeeId", ErrorMessage = "Employee id is not same")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [MinLength(7, ErrorMessage = "Minimum password must be 7 in characters")]
        [Required(ErrorMessage = "Enter valid password")]
        public string Password { get; set; }

        [MinLength(7, ErrorMessage = "Minimum password must be 7 in characters")]
        [Compare("Password", ErrorMessage = "Password is not same")]
        public string ConfirmPassword { get; set; }

        //Foriegn keys

        public string Timestamp { get; set; } = DateTime.Now.ToString();


        //"FOREIGN KEYS"
        [Required(ErrorMessage = "Designation is required")]
        public int DesignationId { get; set; }

        [ValidateNever]
        //[NotMapped]
        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }

        [Required(ErrorMessage = "DepartmentId is required")]
        public int DepartmentId { get; set; }

        [ValidateNever]
        //[NotMapped]
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }


        [Required(ErrorMessage = "Location is required")]
        public int LocationId { get; set; }

        [ValidateNever]
        //[NotMapped]
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }


        [Required(ErrorMessage = "Role is required")]
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        [ValidateNever]
        public virtual Role Role { get; set; }

        [Display(Name = "Reporting to")]
        public int? RepotingPersonId { get; set; }

        [ValidateNever]
        public Employee? ReportingTo { get; set; }

        [ValidateNever]
        public IEnumerable<Employee>? DirectReports { get; set; }
    }
}
