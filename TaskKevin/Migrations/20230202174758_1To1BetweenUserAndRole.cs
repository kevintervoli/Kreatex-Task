using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskKevin.Migrations
{
    public partial class _1To1BetweenUserAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsUser_Projects_ProjectLinkprojectId",
                table: "ProjectsUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Projects_ProjectsprojectId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskUser_Task_TaskLinkId",
                table: "TaskUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "role",
                table: "userTable");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "taskTable");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "projectsTable");

            migrationBuilder.RenameIndex(
                name: "IX_Task_ProjectsprojectId",
                table: "taskTable",
                newName: "IX_taskTable_ProjectsprojectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_taskTable",
                table: "taskTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_projectsTable",
                table: "projectsTable",
                column: "projectId");

            migrationBuilder.CreateTable(
                name: "rolesTable",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolesTable", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_rolesTable_userTable_userId",
                        column: x => x.userId,
                        principalTable: "userTable",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rolesTable_userId",
                table: "rolesTable",
                column: "userId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsUser_projectsTable_ProjectLinkprojectId",
                table: "ProjectsUser",
                column: "ProjectLinkprojectId",
                principalTable: "projectsTable",
                principalColumn: "projectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_taskTable_projectsTable_ProjectsprojectId",
                table: "taskTable",
                column: "ProjectsprojectId",
                principalTable: "projectsTable",
                principalColumn: "projectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskUser_taskTable_TaskLinkId",
                table: "TaskUser",
                column: "TaskLinkId",
                principalTable: "taskTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsUser_projectsTable_ProjectLinkprojectId",
                table: "ProjectsUser");

            migrationBuilder.DropForeignKey(
                name: "FK_taskTable_projectsTable_ProjectsprojectId",
                table: "taskTable");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskUser_taskTable_TaskLinkId",
                table: "TaskUser");

            migrationBuilder.DropTable(
                name: "rolesTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_taskTable",
                table: "taskTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_projectsTable",
                table: "projectsTable");

            migrationBuilder.RenameTable(
                name: "taskTable",
                newName: "Task");

            migrationBuilder.RenameTable(
                name: "projectsTable",
                newName: "Projects");

            migrationBuilder.RenameIndex(
                name: "IX_taskTable_ProjectsprojectId",
                table: "Task",
                newName: "IX_Task_ProjectsprojectId");

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "userTable",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "projectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsUser_Projects_ProjectLinkprojectId",
                table: "ProjectsUser",
                column: "ProjectLinkprojectId",
                principalTable: "Projects",
                principalColumn: "projectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Projects_ProjectsprojectId",
                table: "Task",
                column: "ProjectsprojectId",
                principalTable: "Projects",
                principalColumn: "projectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskUser_Task_TaskLinkId",
                table: "TaskUser",
                column: "TaskLinkId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
