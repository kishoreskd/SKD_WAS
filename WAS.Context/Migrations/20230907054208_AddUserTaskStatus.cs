using Microsoft.EntityFrameworkCore.Migrations;

namespace WAS.Context.Migrations
{
    public partial class AddUserTaskStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AddColumn<int>(
                name: "UserTaskStatusId",
                table: "UserTasks",
                type: "int",
                nullable: true);

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
                  
            migrationBuilder.InsertData(
                table: "UserTaskStatus",
                columns: new[] { "UserTaskStatusId", "Status" },
                values: new object[,]
                {
                    { 1, "Planned" },
                    { 2, "Leave" },
                    { 3, "Training" },
                    { 4, "Notice Period" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_UserTaskStatusId",
                table: "UserTasks",
                column: "UserTaskStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_UserTaskStatus_UserTaskStatusId",
                table: "UserTasks",
                column: "UserTaskStatusId",
                principalTable: "UserTaskStatus",
                principalColumn: "UserTaskStatusId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_UserTaskStatus_UserTaskStatusId",
                table: "UserTasks");

            migrationBuilder.DropTable(
                name: "UserTaskStatus");

            migrationBuilder.DropIndex(
                name: "IX_UserTasks_UserTaskStatusId",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "UserTaskStatusId",
                table: "UserTasks");
        }
    }
}
