using Microsoft.EntityFrameworkCore.Migrations;

namespace WAS.Context.Migrations
{
    public partial class AddProjectModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                PlannedStartDt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PlannedEndDt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ActualStartDt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ActualEndDt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PlannedBudget = table.Column<double>(type: "float", nullable: true),
                TimeStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                IsMainChecked = table.Column<bool>(type: "bit", nullable: false),
                IsMiscChecked = table.Column<bool>(type: "bit", nullable: false),
                IsMainMiscChecked = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ProjectAllocation", x => x.ProjectAllocationId);
            });

            migrationBuilder.CreateTable(
                name: "MainAllocation",
                columns: table => new
                {
                    MainAllocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hours = table.Column<double>(type: "float", nullable: false),
                    Ratio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    R1 = table.Column<double>(type: "float", nullable: false),
                    R2 = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Ratio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    R1 = table.Column<double>(type: "float", nullable: false),
                    R2 = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Ratio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    R1 = table.Column<double>(type: "float", nullable: false),
                    R2 = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainAllocation");

            migrationBuilder.DropTable(
                name: "MainAndMiscAllocation");

            migrationBuilder.DropTable(
                name: "MiscAllocation");

            migrationBuilder.DropTable(
                name: "ProjectAllocation");
        }
    }
}
