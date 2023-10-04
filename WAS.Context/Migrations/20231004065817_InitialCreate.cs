using Microsoft.EntityFrameworkCore.Migrations;

namespace WAS.Context.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Designation",
                columns: table => new
                {
                    DesignationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.DesignationId);
                });

            migrationBuilder.CreateTable(
                name: "Holiday",
                columns: table => new
                {
                    HolidayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HolidayDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holiday", x => x.HolidayId);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectAllocation",
                columns: table => new
                {
                    ProjectAllocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PGTJobNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientJobNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionHours = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMainChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsMiscChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsMainMiscChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAllocation", x => x.ProjectAllocationId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "UserTaskStatus",
                columns: table => new
                {
                    UserTaskStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTaskStatus", x => x.UserTaskStatusId);
                });

            migrationBuilder.CreateTable(
                name: "MainAllocation",
                columns: table => new
                {
                    MainAllocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hours = table.Column<double>(type: "float", nullable: false),
                    R1 = table.Column<double>(type: "float", nullable: false),
                    R2 = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleDays = table.Column<int>(type: "int", nullable: false),
                    ModelerPercent = table.Column<double>(type: "float", nullable: false),
                    CheckerPercent = table.Column<double>(type: "float", nullable: false),
                    DetailerPercent = table.Column<double>(type: "float", nullable: false),
                    IFA = table.Column<double>(type: "float", nullable: false),
                    IFF = table.Column<double>(type: "float", nullable: false),
                    SubmissionDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalResources = table.Column<double>(type: "float", nullable: false),
                    TotalModeler = table.Column<double>(type: "float", nullable: false),
                    TotalChecker = table.Column<double>(type: "float", nullable: false),
                    TotalDetailer = table.Column<double>(type: "float", nullable: false),
                    TotalCoordination = table.Column<double>(type: "float", nullable: false),
                    Ratio1 = table.Column<double>(type: "float", nullable: false),
                    Ratio2 = table.Column<double>(type: "float", nullable: false),
                    ProjectAllocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainAllocation", x => x.MainAllocationId);
                    table.ForeignKey(
                        name: "FK_MainAllocation_ProjectAllocation_ProjectAllocationId",
                        column: x => x.ProjectAllocationId,
                        principalTable: "ProjectAllocation",
                        principalColumn: "ProjectAllocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MainAndMiscAllocation",
                columns: table => new
                {
                    MainAndMiscAllocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hours = table.Column<double>(type: "float", nullable: false),
                    R1 = table.Column<double>(type: "float", nullable: false),
                    R2 = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleDays = table.Column<int>(type: "int", nullable: false),
                    ModelerPercent = table.Column<double>(type: "float", nullable: false),
                    CheckerPercent = table.Column<double>(type: "float", nullable: false),
                    DetailerPercent = table.Column<double>(type: "float", nullable: false),
                    Ratio1 = table.Column<double>(type: "float", nullable: false),
                    Ratio2 = table.Column<double>(type: "float", nullable: false),
                    IFA = table.Column<double>(type: "float", nullable: false),
                    IFF = table.Column<double>(type: "float", nullable: false),
                    SubmissionDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalResources = table.Column<double>(type: "float", nullable: false),
                    TotalModeler = table.Column<double>(type: "float", nullable: false),
                    TotalChecker = table.Column<double>(type: "float", nullable: false),
                    TotalDetailer = table.Column<double>(type: "float", nullable: false),
                    TotalCoordination = table.Column<double>(type: "float", nullable: false),
                    ProjectAllocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainAndMiscAllocation", x => x.MainAndMiscAllocationId);
                    table.ForeignKey(
                        name: "FK_MainAndMiscAllocation_ProjectAllocation_ProjectAllocationId",
                        column: x => x.ProjectAllocationId,
                        principalTable: "ProjectAllocation",
                        principalColumn: "ProjectAllocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MiscAllocation",
                columns: table => new
                {
                    MiscAllocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hours = table.Column<double>(type: "float", nullable: false),
                    R1 = table.Column<double>(type: "float", nullable: false),
                    R2 = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleDays = table.Column<int>(type: "int", nullable: false),
                    ModelerPercent = table.Column<double>(type: "float", nullable: false),
                    DetailerPercent = table.Column<double>(type: "float", nullable: false),
                    CheckerPercent = table.Column<double>(type: "float", nullable: false),
                    IFA = table.Column<double>(type: "float", nullable: false),
                    IFF = table.Column<double>(type: "float", nullable: false),
                    SubmissionDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalResources = table.Column<double>(type: "float", nullable: false),
                    TotalModeler = table.Column<double>(type: "float", nullable: false),
                    TotalChecker = table.Column<double>(type: "float", nullable: false),
                    TotalDetailer = table.Column<double>(type: "float", nullable: false),
                    TotalCoordination = table.Column<double>(type: "float", nullable: false),
                    Ratio1 = table.Column<double>(type: "float", nullable: false),
                    Ratio2 = table.Column<double>(type: "float", nullable: false),
                    ProjectAllocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiscAllocation", x => x.MiscAllocationId);
                    table.ForeignKey(
                        name: "FK_MiscAllocation_ProjectAllocation_ProjectAllocationId",
                        column: x => x.ProjectAllocationId,
                        principalTable: "ProjectAllocation",
                        principalColumn: "ProjectAllocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfJoining = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalExperiance = table.Column<int>(type: "int", nullable: false),
                    ExperianceInThisDep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypesOfJobHandle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    RepotingPersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designation",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Employee_RepotingPersonId",
                        column: x => x.RepotingPersonId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTasks",
                columns: table => new
                {
                    UserTasksId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectAllocationId = table.Column<int>(type: "int", nullable: true),
                    UserAccountId = table.Column<int>(type: "int", nullable: false),
                    UserTaskStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTasks", x => x.UserTasksId);
                    table.ForeignKey(
                        name: "FK_UserTasks_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTasks_Employee_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTasks_ProjectAllocation_ProjectAllocationId",
                        column: x => x.ProjectAllocationId,
                        principalTable: "ProjectAllocation",
                        principalColumn: "ProjectAllocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTasks_UserTaskStatus_UserTaskStatusId",
                        column: x => x.UserTaskStatusId,
                        principalTable: "UserTaskStatus",
                        principalColumn: "UserTaskStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Steel" },
                    { 2, "Rebar" },
                    { 3, "Automation" },
                    { 4, "Hr" }
                });

            migrationBuilder.InsertData(
                table: "Designation",
                columns: new[] { "DesignationId", "DepartmentId", "DesignationName" },
                values: new object[,]
                {
                    { 1, 1, "Modeler" },
                    { 2, 1, "Checker" },
                    { 3, 1, "Detailer" },
                    { 4, 1, "Developer" },
                    { 5, 1, "HOD" },
                    { 6, 1, "TL" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "LocationId", "LocationName" },
                values: new object[,]
                {
                    { 4, "Nashik" },
                    { 3, "Thane" },
                    { 1, "Chennai" },
                    { 2, "Trichy" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "RoleName" },
                values: new object[,]
                {
                    { 1, "Super Admin" },
                    { 2, "Admin" },
                    { 3, "Manager" },
                    { 4, "User" }
                });

            migrationBuilder.InsertData(
                table: "UserTaskStatus",
                columns: new[] { "UserTaskStatusId", "Status" },
                values: new object[,]
                {
                    { 3, "Training" },
                    { 1, "Planned" },
                    { 2, "Leave" },
                    { 4, "Notice Period" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Address", "BloodGroup", "ConfirmPassword", "DOB", "DateOfJoining", "DepartmentId", "DesignationId", "EmailID", "EmployeeId", "ExperianceInThisDep", "Gender", "LocationId", "MobileNumber", "Name", "Password", "RepotingPersonId", "RoleId", "Timestamp", "TotalExperiance", "TypesOfJobHandle", "UserName" },
                values: new object[,]
                {
                    { 1, "Chennai", "O+", "zxzZoZhWLPpvHqvau3cfzg==", "30/07/2023", "26/07/2023", 1, 3, "ks@gmail.com", "2701", null, 1, 1, "9597073502", "Kishore S", "zxzZoZhWLPpvHqvau3cfzg==", null, 2, "10/4/2023 12:28:17 PM", 2, null, "2701" },
                    { 2, "Chennai", "O+", "zxzZoZhWLPpvHqvau3cfzg==", "30/07/2023", "26/07/2023", 1, 5, "ks@gmail.com", "2702", null, 1, 1, "9597073502", "Srivathsan", "zxzZoZhWLPpvHqvau3cfzg==", null, 3, "10/4/2023 12:28:17 PM", 2, null, "2702" },
                    { 3, "Chennai", "O+", "zxzZoZhWLPpvHqvau3cfzg==", "30/07/2023", "26/07/2023", 1, 6, "ks@gmail.com", "2703", null, 1, 1, "9597073502", "Sivahari Senthilkumar", "zxzZoZhWLPpvHqvau3cfzg==", null, 4, "10/4/2023 12:28:17 PM", 2, null, "2703" },
                    { 4, "Chennai", "O+", "zxzZoZhWLPpvHqvau3cfzg==", "30/07/2023", "26/07/2023", 1, 2, "ks@gmail.com", "2704", null, 1, 1, "9597073502", "Ashok", "zxzZoZhWLPpvHqvau3cfzg==", null, 4, "10/4/2023 12:28:17 PM", 2, null, "2704" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DesignationId",
                table: "Employee",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_LocationId",
                table: "Employee",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RepotingPersonId",
                table: "Employee",
                column: "RepotingPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RoleId",
                table: "Employee",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MainAllocation_ProjectAllocationId",
                table: "MainAllocation",
                column: "ProjectAllocationId",
                unique: true,
                filter: "[ProjectAllocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MainAndMiscAllocation_ProjectAllocationId",
                table: "MainAndMiscAllocation",
                column: "ProjectAllocationId",
                unique: true,
                filter: "[ProjectAllocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MiscAllocation_ProjectAllocationId",
                table: "MiscAllocation",
                column: "ProjectAllocationId",
                unique: true,
                filter: "[ProjectAllocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_EmployeeId",
                table: "UserTasks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_ProjectAllocationId",
                table: "UserTasks",
                column: "ProjectAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_UserAccountId",
                table: "UserTasks",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_UserTaskStatusId",
                table: "UserTasks",
                column: "UserTaskStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holiday");

            migrationBuilder.DropTable(
                name: "MainAllocation");

            migrationBuilder.DropTable(
                name: "MainAndMiscAllocation");

            migrationBuilder.DropTable(
                name: "MiscAllocation");

            migrationBuilder.DropTable(
                name: "UserTasks");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "ProjectAllocation");

            migrationBuilder.DropTable(
                name: "UserTaskStatus");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Designation");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
