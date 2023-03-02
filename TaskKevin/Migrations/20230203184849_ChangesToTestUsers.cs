using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskKevin.Migrations
{
    public partial class ChangesToTestUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userTable_rolesTable_rolesId",
                table: "userTable");

            migrationBuilder.DropTable(
                name: "ProjectsUser");

            migrationBuilder.DropTable(
                name: "TaskUser");

            migrationBuilder.DropIndex(
                name: "IX_userTable_rolesId",
                table: "userTable");

            migrationBuilder.DropColumn(
                name: "rolesId",
                table: "userTable");

            migrationBuilder.AddColumn<int>(
                name: "ProjectsprojectId",
                table: "userTable",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "userTable",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "userTable",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userLinkid",
                table: "rolesTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_userTable_ProjectsprojectId",
                table: "userTable",
                column: "ProjectsprojectId");

            migrationBuilder.CreateIndex(
                name: "IX_userTable_TaskId",
                table: "userTable",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_rolesTable_userLinkid",
                table: "rolesTable",
                column: "userLinkid");

            migrationBuilder.AddForeignKey(
                name: "FK_rolesTable_userTable_userLinkid",
                table: "rolesTable",
                column: "userLinkid",
                principalTable: "userTable",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userTable_projectsTable_ProjectsprojectId",
                table: "userTable",
                column: "ProjectsprojectId",
                principalTable: "projectsTable",
                principalColumn: "projectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userTable_taskTable_TaskId",
                table: "userTable",
                column: "TaskId",
                principalTable: "taskTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rolesTable_userTable_userLinkid",
                table: "rolesTable");

            migrationBuilder.DropForeignKey(
                name: "FK_userTable_projectsTable_ProjectsprojectId",
                table: "userTable");

            migrationBuilder.DropForeignKey(
                name: "FK_userTable_taskTable_TaskId",
                table: "userTable");

            migrationBuilder.DropIndex(
                name: "IX_userTable_ProjectsprojectId",
                table: "userTable");

            migrationBuilder.DropIndex(
                name: "IX_userTable_TaskId",
                table: "userTable");

            migrationBuilder.DropIndex(
                name: "IX_rolesTable_userLinkid",
                table: "rolesTable");

            migrationBuilder.DropColumn(
                name: "ProjectsprojectId",
                table: "userTable");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "userTable");

            migrationBuilder.DropColumn(
                name: "role",
                table: "userTable");

            migrationBuilder.DropColumn(
                name: "userLinkid",
                table: "rolesTable");

            migrationBuilder.AddColumn<int>(
                name: "rolesId",
                table: "userTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProjectsUser",
                columns: table => new
                {
                    ProjectLinkprojectId = table.Column<int>(type: "int", nullable: false),
                    Userid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsUser", x => new { x.ProjectLinkprojectId, x.Userid });
                    table.ForeignKey(
                        name: "FK_ProjectsUser_projectsTable_ProjectLinkprojectId",
                        column: x => x.ProjectLinkprojectId,
                        principalTable: "projectsTable",
                        principalColumn: "projectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectsUser_userTable_Userid",
                        column: x => x.Userid,
                        principalTable: "userTable",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskUser",
                columns: table => new
                {
                    TaskLinkId = table.Column<int>(type: "int", nullable: false),
                    UserLinkid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskUser", x => new { x.TaskLinkId, x.UserLinkid });
                    table.ForeignKey(
                        name: "FK_TaskUser_taskTable_TaskLinkId",
                        column: x => x.TaskLinkId,
                        principalTable: "taskTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskUser_userTable_UserLinkid",
                        column: x => x.UserLinkid,
                        principalTable: "userTable",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userTable_rolesId",
                table: "userTable",
                column: "rolesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsUser_Userid",
                table: "ProjectsUser",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_TaskUser_UserLinkid",
                table: "TaskUser",
                column: "UserLinkid");

            migrationBuilder.AddForeignKey(
                name: "FK_userTable_rolesTable_rolesId",
                table: "userTable",
                column: "rolesId",
                principalTable: "rolesTable",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
