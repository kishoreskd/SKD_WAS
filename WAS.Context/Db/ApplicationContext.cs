using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WAS.Model;
using WAS.Interface;


using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WAS.Utility;

namespace WAS.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> option) : base(option)
        {

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Holiday> Holiday { get; set; }
        public DbSet<Role> Role { get; set; }



        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectEstimation> ProjectEstimation { get; set; }
        public DbSet<UserTasks> UserTasks { get; set; }
        public DbSet<UserTaskStatus> UserTaskStatus { get; set; }


        public DbSet<ProjectAllocation> ProjectAllocation { get; set; }
        public DbSet<MainAllocation> MainAllocation { get; set; }
        public DbSet<MiscAllocation> MiscAllocation { get; set; }
        public DbSet<MainAndMiscAllocation> MainAndMiscAllocation { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>()
                .HasOne(emp => emp.ReportingTo)
                .WithMany(emp => emp.DirectReports)
                .HasForeignKey(emp => emp.RepotingPersonId)
                .OnDelete(DeleteBehavior.Restrict);



            //builder.Entity<TaskActivity>()
            //    .HasMany(task => task.AssignedTask)
            //    .WithOne(task => task.TaskActivity);

            //builder.Entity<Activity_AssignedTask>()
            //    .HasOne(activity => activity.Activity)
            //    .WithMany(activityTask => activityTask.Activity_AssignedTask)
            //    .HasForeignKey(activityTask => activityTask.ActivityId);

            //builder.Entity<Activity_AssignedTask>()
            //    .HasOne(assigned => assigned.AssignedTask)
            //     .WithMany(activityTask => activityTask.Activity_AssignedTask)
            //     .HasForeignKey(activityTask => activityTask.AssignedTaskId);


            builder.Entity<Location>().HasData(
               new Location { LocationId = 1, LocationName = "Chennai" },
               new Location { LocationId = 2, LocationName = "Trichy" },
               new Location { LocationId = 3, LocationName = "Thane" },
               new Location { LocationId = 4, LocationName = "Nashik" });

            builder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "Steel" },
                new Department { DepartmentId = 2, DepartmentName = "Rebar" },
                new Department { DepartmentId = 3, DepartmentName = "Automation" },
                new Department { DepartmentId = 4, DepartmentName = "Hr" });

            builder.Entity<Designation>().HasData(
                new Designation { DesignationId = 1, DepartmentId = 1, DesignationName = "Modeler" },
                new Designation { DesignationId = 2, DepartmentId = 1, DesignationName = "Checker" },
                new Designation { DesignationId = 3, DepartmentId = 1, DesignationName = "Detailer" },
                new Designation { DesignationId = 4, DepartmentId = 1, DesignationName = "Developer" },
                new Designation { DesignationId = 5, DepartmentId = 1, DesignationName = "HOD" },
                new Designation { DesignationId = 6, DepartmentId = 1, DesignationName = "TL" });

            builder.Entity<Role>().HasData(
                new Role { RoleID = 1, RoleName = "Super Admin" },
                new Role { RoleID = 2, RoleName = "Admin" },
                new Role { RoleID = 3, RoleName = "Manager" },
                new Role { RoleID = 4, RoleName = "User" });

            builder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Address = "Chennai",
                    RepotingPersonId = null,
                    BloodGroup = "O+",
                    Password = "zxzZoZhWLPpvHqvau3cfzg==",
                    ConfirmPassword = "zxzZoZhWLPpvHqvau3cfzg==",
                    DateOfJoining = "26/07/2023",
                    DepartmentId = 1,
                    DesignationId = 3,
                    EmployeeId = "2701",
                    EmailID = "ks@gmail.com",
                    Name = "Kishore S",
                    DOB = "30/07/2023",
                    ExperianceInThisDep = null,
                    Gender = 1,
                    LocationId = 1,
                    RoleId = 2,
                    MobileNumber = "9597073502",
                    UserName = "2701",
                    TypesOfJobHandle = null,
                    TotalExperiance = 2,

                },
                new Employee
                {
                    Id = 2,
                    Address = "Chennai",
                    RepotingPersonId = null,
                    BloodGroup = "O+",
                    Password = "zxzZoZhWLPpvHqvau3cfzg==",
                    ConfirmPassword = "zxzZoZhWLPpvHqvau3cfzg==",
                    DateOfJoining = "26/07/2023",
                    DepartmentId = 1,
                    DesignationId = 5,
                    EmployeeId = "2702",
                    EmailID = "ks@gmail.com",
                    Name = "Srivathsan",
                    DOB = "30/07/2023",
                    ExperianceInThisDep = null,
                    Gender = 1,
                    LocationId = 1,
                    RoleId = 3,
                    MobileNumber = "9597073502",
                    UserName = "2702",
                    TypesOfJobHandle = null,
                    TotalExperiance = 2
                },
                new Employee
                {
                    Id = 3,
                    Address = "Chennai",
                    RepotingPersonId = null,
                    BloodGroup = "O+",
                    Password = "zxzZoZhWLPpvHqvau3cfzg==",
                    ConfirmPassword = "zxzZoZhWLPpvHqvau3cfzg==",
                    DateOfJoining = "26/07/2023",
                    DepartmentId = 1,
                    DesignationId = 6,
                    EmployeeId = "2703",
                    EmailID = "ks@gmail.com",
                    Name = "Sivahari Senthilkumar",
                    DOB = "30/07/2023",
                    ExperianceInThisDep = null,
                    Gender = 1,
                    LocationId = 1,
                    RoleId = 4,
                    MobileNumber = "9597073502",
                    UserName = "2703",
                    TypesOfJobHandle = null,
                    TotalExperiance = 2
                },
                new Employee
                {
                    Id = 4,
                    Address = "Chennai",
                    RepotingPersonId = null,
                    BloodGroup = "O+",
                    Password = "zxzZoZhWLPpvHqvau3cfzg==",
                    ConfirmPassword = "zxzZoZhWLPpvHqvau3cfzg==",
                    DateOfJoining = "26/07/2023",
                    DepartmentId = 1,
                    DesignationId = 2,
                    EmployeeId = "2704",
                    EmailID = "ks@gmail.com",
                    Name = "Ashok",
                    DOB = "30/07/2023",
                    ExperianceInThisDep = null,
                    Gender = 1,
                    LocationId = 1,
                    RoleId = 4,
                    MobileNumber = "9597073502",
                    UserName = "2704",
                    TypesOfJobHandle = null,
                    TotalExperiance = 2
                });

            builder.Entity<UserTaskStatus>().HasData(
                new UserTaskStatus { UserTaskStatusId = 1, Status = "Planned" },
                new UserTaskStatus { UserTaskStatusId = 2, Status = "Leave" },
                new UserTaskStatus { UserTaskStatusId = 3, Status = "Training" },
                new UserTaskStatus { UserTaskStatusId = 4, Status = "Notice Period" });
        }
    }
}
