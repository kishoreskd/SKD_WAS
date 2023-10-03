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
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PGTJobNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientJobNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainH = table.Column<double>(type: "float", nullable: false),
                    MainStartDt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiscH = table.Column<double>(type: "float", nullable: false),
                    MiscStartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConnectionH = table.Column<double>(type: "float", nullable: false),
                    StairH = table.Column<double>(type: "float", nullable: false),
                    TotalH = table.Column<double>(type: "float", nullable: false),
                    Ratio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainSDt = table.Column<int>(type: "int", nullable: false),
                    MiscSDt = table.Column<int>(type: "int", nullable: false),
                    WHPerday = table.Column<double>(type: "float", nullable: false),
                    MainModelersNdPercent = table.Column<double>(type: "float", nullable: false),
                    MainDetilersNdPercent = table.Column<double>(type: "float", nullable: false),
                    MainCheckersNdPercent = table.Column<double>(type: "float", nullable: false),
                    MiscModelersNdPercent = table.Column<double>(type: "float", nullable: false),
                    MiscDetilersNdPercent = table.Column<double>(type: "float", nullable: false),
                    MiscCheckersNdPercent = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlannedStartDt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlannedEndDt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualStartDt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualEndDt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlannedBudget = table.Column<double>(type: "float", nullable: true),
                    TimeStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
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
                name: "ProjectEstimation",
                columns: table => new
                {
                    ProjectEstimationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IFAr1r2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IFFr1r2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainSubmissionDt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiscSubmissionDt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResourcesMain = table.Column<double>(type: "float", nullable: false),
                    ResourcesMisc = table.Column<double>(type: "float", nullable: false),
                    MainMNd = table.Column<double>(type: "float", nullable: false),
                    MainDNd = table.Column<double>(type: "float", nullable: false),
                    MainCNd = table.Column<double>(type: "float", nullable: false),
                    MiscMNd = table.Column<double>(type: "float", nullable: false),
                    MiscDNd = table.Column<double>(type: "float", nullable: false),
                    MiscCNd = table.Column<double>(type: "float", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEstimation", x => x.ProjectEstimationId);
                    table.ForeignKey(
                        name: "FK_ProjectEstimation_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designation",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
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
                    { 6, 1, "TL" },
                    { 4, 1, "Developer" },
                    { 5, 1, "HOD" },
                    { 2, 1, "Checker" },
                    { 1, 1, "Modeler" },
                    { 3, 1, "Detailer" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "LocationId", "LocationName" },
                values: new object[,]
                {
                    { 1, "Chennai" },
                    { 2, "Trichy" },
                    { 3, "Thane" },
                    { 4, "Nashik" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "RoleName" },
                values: new object[,]
                {
                    { 3, "Manager" },
                    { 1, "Super Admin" },
                    { 2, "Admin" },
                    { 4, "User" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Address", "BloodGroup", "ConfirmPassword", "DOB", "DateOfJoining", "DepartmentId", "DesignationId", "EmailID", "EmployeeId", "ExperianceInThisDep", "Gender", "LocationId", "MobileNumber", "Name", "Password", "RepotingPersonId", "RoleId", "Timestamp", "TotalExperiance", "TypesOfJobHandle", "UserName" },
                values: new object[,]
                {
                    { 1, "Chennai", "O+", "zxzZoZhWLPpvHqvau3cfzg==", "30/07/2023", "26/07/2023", 1, 3, "ks@gmail.com", "2701", null, 1, 1, "9597073502", "Kishore S", "zxzZoZhWLPpvHqvau3cfzg==", null, 2, "29-08-2023", 2, null, "2701" },
                    { 2, "Chennai", "O+", "zxzZoZhWLPpvHqvau3cfzg==", "30/07/2023", "26/07/2023", 1, 5, "ks@gmail.com", "2702", null, 1, 1, "9597073502", "Srivathsan", "zxzZoZhWLPpvHqvau3cfzg==", null, 3, "29-08-2023", 2, null, "2702" },
                    { 3, "Chennai", "O+", "zxzZoZhWLPpvHqvau3cfzg==", "30/07/2023", "26/07/2023", 1, 6, "ks@gmail.com", "2703", null, 1, 1, "9597073502", "Sivahari Senthilkumar", "zxzZoZhWLPpvHqvau3cfzg==", null, 4, "29-08-2023", 2, null, "2703" },
                    { 4, "Chennai", "O+", "zxzZoZhWLPpvHqvau3cfzg==", "30/07/2023", "26/07/2023", 1, 2, "ks@gmail.com", "2704", null, 1, 1, "9597073502", "Ashok", "zxzZoZhWLPpvHqvau3cfzg==", null, 4, "29-08-2023", 2, null, "2704" }
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
                name: "IX_ProjectEstimation_ProjectId",
                table: "ProjectEstimation",
                column: "ProjectId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Holiday");

            migrationBuilder.DropTable(
                name: "ProjectEstimation");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Designation");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
