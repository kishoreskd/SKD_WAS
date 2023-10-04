﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WAS.Context;

namespace WAS.Context.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231004065817_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WAS.Model.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            DepartmentName = "Steel"
                        },
                        new
                        {
                            DepartmentId = 2,
                            DepartmentName = "Rebar"
                        },
                        new
                        {
                            DepartmentId = 3,
                            DepartmentName = "Automation"
                        },
                        new
                        {
                            DepartmentId = 4,
                            DepartmentName = "Hr"
                        });
                });

            modelBuilder.Entity("WAS.Model.Designation", b =>
                {
                    b.Property<int>("DesignationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("DesignationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DesignationId");

                    b.ToTable("Designation");

                    b.HasData(
                        new
                        {
                            DesignationId = 1,
                            DepartmentId = 1,
                            DesignationName = "Modeler"
                        },
                        new
                        {
                            DesignationId = 2,
                            DepartmentId = 1,
                            DesignationName = "Checker"
                        },
                        new
                        {
                            DesignationId = 3,
                            DepartmentId = 1,
                            DesignationName = "Detailer"
                        },
                        new
                        {
                            DesignationId = 4,
                            DepartmentId = 1,
                            DesignationName = "Developer"
                        },
                        new
                        {
                            DesignationId = 5,
                            DepartmentId = 1,
                            DesignationName = "HOD"
                        },
                        new
                        {
                            DesignationId = 6,
                            DepartmentId = 1,
                            DesignationName = "TL"
                        });
                });

            modelBuilder.Entity("WAS.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BloodGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfirmPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DOB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateOfJoining")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("DesignationId")
                        .HasColumnType("int");

                    b.Property<string>("EmailID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("ExperianceInThisDep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RepotingPersonId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Timestamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalExperiance")
                        .HasColumnType("int");

                    b.Property<string>("TypesOfJobHandle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DesignationId");

                    b.HasIndex("LocationId");

                    b.HasIndex("RepotingPersonId");

                    b.HasIndex("RoleId");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Chennai",
                            BloodGroup = "O+",
                            ConfirmPassword = "zxzZoZhWLPpvHqvau3cfzg==",
                            DOB = "30/07/2023",
                            DateOfJoining = "26/07/2023",
                            DepartmentId = 1,
                            DesignationId = 3,
                            EmailID = "ks@gmail.com",
                            EmployeeId = "2701",
                            Gender = 1,
                            LocationId = 1,
                            MobileNumber = "9597073502",
                            Name = "Kishore S",
                            Password = "zxzZoZhWLPpvHqvau3cfzg==",
                            RoleId = 2,
                            Timestamp = "10/4/2023 12:28:17 PM",
                            TotalExperiance = 2,
                            UserName = "2701"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Chennai",
                            BloodGroup = "O+",
                            ConfirmPassword = "zxzZoZhWLPpvHqvau3cfzg==",
                            DOB = "30/07/2023",
                            DateOfJoining = "26/07/2023",
                            DepartmentId = 1,
                            DesignationId = 5,
                            EmailID = "ks@gmail.com",
                            EmployeeId = "2702",
                            Gender = 1,
                            LocationId = 1,
                            MobileNumber = "9597073502",
                            Name = "Srivathsan",
                            Password = "zxzZoZhWLPpvHqvau3cfzg==",
                            RoleId = 3,
                            Timestamp = "10/4/2023 12:28:17 PM",
                            TotalExperiance = 2,
                            UserName = "2702"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Chennai",
                            BloodGroup = "O+",
                            ConfirmPassword = "zxzZoZhWLPpvHqvau3cfzg==",
                            DOB = "30/07/2023",
                            DateOfJoining = "26/07/2023",
                            DepartmentId = 1,
                            DesignationId = 6,
                            EmailID = "ks@gmail.com",
                            EmployeeId = "2703",
                            Gender = 1,
                            LocationId = 1,
                            MobileNumber = "9597073502",
                            Name = "Sivahari Senthilkumar",
                            Password = "zxzZoZhWLPpvHqvau3cfzg==",
                            RoleId = 4,
                            Timestamp = "10/4/2023 12:28:17 PM",
                            TotalExperiance = 2,
                            UserName = "2703"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Chennai",
                            BloodGroup = "O+",
                            ConfirmPassword = "zxzZoZhWLPpvHqvau3cfzg==",
                            DOB = "30/07/2023",
                            DateOfJoining = "26/07/2023",
                            DepartmentId = 1,
                            DesignationId = 2,
                            EmailID = "ks@gmail.com",
                            EmployeeId = "2704",
                            Gender = 1,
                            LocationId = 1,
                            MobileNumber = "9597073502",
                            Name = "Ashok",
                            Password = "zxzZoZhWLPpvHqvau3cfzg==",
                            RoleId = 4,
                            Timestamp = "10/4/2023 12:28:17 PM",
                            TotalExperiance = 2,
                            UserName = "2704"
                        });
                });

            modelBuilder.Entity("WAS.Model.Holiday", b =>
                {
                    b.Property<int>("HolidayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("HolidayDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HolidayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HolidayId");

                    b.ToTable("Holiday");
                });

            modelBuilder.Entity("WAS.Model.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Location");

                    b.HasData(
                        new
                        {
                            LocationId = 1,
                            LocationName = "Chennai"
                        },
                        new
                        {
                            LocationId = 2,
                            LocationName = "Trichy"
                        },
                        new
                        {
                            LocationId = 3,
                            LocationName = "Thane"
                        },
                        new
                        {
                            LocationId = 4,
                            LocationName = "Nashik"
                        });
                });

            modelBuilder.Entity("WAS.Model.MainAllocation", b =>
                {
                    b.Property<int>("MainAllocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("CheckerPercent")
                        .HasColumnType("float");

                    b.Property<double>("DetailerPercent")
                        .HasColumnType("float");

                    b.Property<double>("Hours")
                        .HasColumnType("float");

                    b.Property<double>("IFA")
                        .HasColumnType("float");

                    b.Property<double>("IFF")
                        .HasColumnType("float");

                    b.Property<double>("ModelerPercent")
                        .HasColumnType("float");

                    b.Property<int?>("ProjectAllocationId")
                        .HasColumnType("int");

                    b.Property<double>("R1")
                        .HasColumnType("float");

                    b.Property<double>("R2")
                        .HasColumnType("float");

                    b.Property<double>("Ratio1")
                        .HasColumnType("float");

                    b.Property<double>("Ratio2")
                        .HasColumnType("float");

                    b.Property<int>("ScheduleDays")
                        .HasColumnType("int");

                    b.Property<string>("StartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubmissionDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalChecker")
                        .HasColumnType("float");

                    b.Property<double>("TotalCoordination")
                        .HasColumnType("float");

                    b.Property<double>("TotalDetailer")
                        .HasColumnType("float");

                    b.Property<double>("TotalModeler")
                        .HasColumnType("float");

                    b.Property<double>("TotalResources")
                        .HasColumnType("float");

                    b.HasKey("MainAllocationId");

                    b.HasIndex("ProjectAllocationId")
                        .IsUnique()
                        .HasFilter("[ProjectAllocationId] IS NOT NULL");

                    b.ToTable("MainAllocation");
                });

            modelBuilder.Entity("WAS.Model.MainAndMiscAllocation", b =>
                {
                    b.Property<int>("MainAndMiscAllocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("CheckerPercent")
                        .HasColumnType("float");

                    b.Property<double>("DetailerPercent")
                        .HasColumnType("float");

                    b.Property<double>("Hours")
                        .HasColumnType("float");

                    b.Property<double>("IFA")
                        .HasColumnType("float");

                    b.Property<double>("IFF")
                        .HasColumnType("float");

                    b.Property<double>("ModelerPercent")
                        .HasColumnType("float");

                    b.Property<int?>("ProjectAllocationId")
                        .HasColumnType("int");

                    b.Property<double>("R1")
                        .HasColumnType("float");

                    b.Property<double>("R2")
                        .HasColumnType("float");

                    b.Property<double>("Ratio1")
                        .HasColumnType("float");

                    b.Property<double>("Ratio2")
                        .HasColumnType("float");

                    b.Property<int>("ScheduleDays")
                        .HasColumnType("int");

                    b.Property<string>("StartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubmissionDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalChecker")
                        .HasColumnType("float");

                    b.Property<double>("TotalCoordination")
                        .HasColumnType("float");

                    b.Property<double>("TotalDetailer")
                        .HasColumnType("float");

                    b.Property<double>("TotalModeler")
                        .HasColumnType("float");

                    b.Property<double>("TotalResources")
                        .HasColumnType("float");

                    b.HasKey("MainAndMiscAllocationId");

                    b.HasIndex("ProjectAllocationId")
                        .IsUnique()
                        .HasFilter("[ProjectAllocationId] IS NOT NULL");

                    b.ToTable("MainAndMiscAllocation");
                });

            modelBuilder.Entity("WAS.Model.MiscAllocation", b =>
                {
                    b.Property<int>("MiscAllocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("CheckerPercent")
                        .HasColumnType("float");

                    b.Property<double>("DetailerPercent")
                        .HasColumnType("float");

                    b.Property<double>("Hours")
                        .HasColumnType("float");

                    b.Property<double>("IFA")
                        .HasColumnType("float");

                    b.Property<double>("IFF")
                        .HasColumnType("float");

                    b.Property<double>("ModelerPercent")
                        .HasColumnType("float");

                    b.Property<int?>("ProjectAllocationId")
                        .HasColumnType("int");

                    b.Property<double>("R1")
                        .HasColumnType("float");

                    b.Property<double>("R2")
                        .HasColumnType("float");

                    b.Property<double>("Ratio1")
                        .HasColumnType("float");

                    b.Property<double>("Ratio2")
                        .HasColumnType("float");

                    b.Property<int>("ScheduleDays")
                        .HasColumnType("int");

                    b.Property<string>("StartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubmissionDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalChecker")
                        .HasColumnType("float");

                    b.Property<double>("TotalCoordination")
                        .HasColumnType("float");

                    b.Property<double>("TotalDetailer")
                        .HasColumnType("float");

                    b.Property<double>("TotalModeler")
                        .HasColumnType("float");

                    b.Property<double>("TotalResources")
                        .HasColumnType("float");

                    b.HasKey("MiscAllocationId");

                    b.HasIndex("ProjectAllocationId")
                        .IsUnique()
                        .HasFilter("[ProjectAllocationId] IS NOT NULL");

                    b.ToTable("MiscAllocation");
                });

            modelBuilder.Entity("WAS.Model.ProjectAllocation", b =>
                {
                    b.Property<int>("ProjectAllocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClientJobNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMainChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMainMiscChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMiscChecked")
                        .HasColumnType("bit");

                    b.Property<string>("PGTJobNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProductionHours")
                        .HasColumnType("float");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectAllocationId");

                    b.ToTable("ProjectAllocation");
                });

            modelBuilder.Entity("WAS.Model.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            RoleID = 1,
                            RoleName = "Super Admin"
                        },
                        new
                        {
                            RoleID = 2,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleID = 3,
                            RoleName = "Manager"
                        },
                        new
                        {
                            RoleID = 4,
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("WAS.Model.UserTaskStatus", b =>
                {
                    b.Property<int>("UserTaskStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserTaskStatusId");

                    b.ToTable("UserTaskStatus");

                    b.HasData(
                        new
                        {
                            UserTaskStatusId = 1,
                            Status = "Planned"
                        },
                        new
                        {
                            UserTaskStatusId = 2,
                            Status = "Leave"
                        },
                        new
                        {
                            UserTaskStatusId = 3,
                            Status = "Training"
                        },
                        new
                        {
                            UserTaskStatusId = 4,
                            Status = "Notice Period"
                        });
                });

            modelBuilder.Entity("WAS.Model.UserTasks", b =>
                {
                    b.Property<int>("UserTasksId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectAllocationId")
                        .HasColumnType("int");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TimeStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserAccountId")
                        .HasColumnType("int");

                    b.Property<int?>("UserTaskStatusId")
                        .HasColumnType("int");

                    b.HasKey("UserTasksId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectAllocationId");

                    b.HasIndex("UserAccountId");

                    b.HasIndex("UserTaskStatusId");

                    b.ToTable("UserTasks");
                });

            modelBuilder.Entity("WAS.Model.Employee", b =>
                {
                    b.HasOne("WAS.Model.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WAS.Model.Designation", "Designation")
                        .WithMany()
                        .HasForeignKey("DesignationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WAS.Model.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WAS.Model.Employee", "ReportingTo")
                        .WithMany("DirectReports")
                        .HasForeignKey("RepotingPersonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WAS.Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Designation");

                    b.Navigation("Location");

                    b.Navigation("ReportingTo");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WAS.Model.MainAllocation", b =>
                {
                    b.HasOne("WAS.Model.ProjectAllocation", "ProjectAllocation")
                        .WithOne("MainAllocation")
                        .HasForeignKey("WAS.Model.MainAllocation", "ProjectAllocationId");

                    b.Navigation("ProjectAllocation");
                });

            modelBuilder.Entity("WAS.Model.MainAndMiscAllocation", b =>
                {
                    b.HasOne("WAS.Model.ProjectAllocation", "ProjectAllocation")
                        .WithOne("MainAndMiscAllocation")
                        .HasForeignKey("WAS.Model.MainAndMiscAllocation", "ProjectAllocationId");

                    b.Navigation("ProjectAllocation");
                });

            modelBuilder.Entity("WAS.Model.MiscAllocation", b =>
                {
                    b.HasOne("WAS.Model.ProjectAllocation", "ProjectAllocation")
                        .WithOne("MiscAllocation")
                        .HasForeignKey("WAS.Model.MiscAllocation", "ProjectAllocationId");

                    b.Navigation("ProjectAllocation");
                });

            modelBuilder.Entity("WAS.Model.UserTasks", b =>
                {
                    b.HasOne("WAS.Model.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WAS.Model.ProjectAllocation", "ProjectAllocation")
                        .WithMany()
                        .HasForeignKey("ProjectAllocationId");

                    b.HasOne("WAS.Model.Employee", "UserAccountEmployee")
                        .WithMany()
                        .HasForeignKey("UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WAS.Model.UserTaskStatus", "UserTaskStatus")
                        .WithMany()
                        .HasForeignKey("UserTaskStatusId");

                    b.Navigation("Employee");

                    b.Navigation("ProjectAllocation");

                    b.Navigation("UserAccountEmployee");

                    b.Navigation("UserTaskStatus");
                });

            modelBuilder.Entity("WAS.Model.Employee", b =>
                {
                    b.Navigation("DirectReports");
                });

            modelBuilder.Entity("WAS.Model.ProjectAllocation", b =>
                {
                    b.Navigation("MainAllocation");

                    b.Navigation("MainAndMiscAllocation");

                    b.Navigation("MiscAllocation");
                });
#pragma warning restore 612, 618
        }
    }
}