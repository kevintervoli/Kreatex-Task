using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskKevin.Migrations
{
    public partial class OptimisedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    projectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    projectData = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    dateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.projectId);
                });

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
                        name: "FK_ProjectsUser_Projects_ProjectLinkprojectId",
                        column: x => x.ProjectLinkprojectId,
                        principalTable: "Projects",
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
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taskName = table.Column<int>(type: "int", maxLength: 256, nullable: false),
                    taskProperties = table.Column<int>(type: "int", maxLength: 512, nullable: false),
                    completed = table.Column<bool>(type: "bit", nullable: false),
                    ProjectsprojectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Projects_ProjectsprojectId",
                        column: x => x.ProjectsprojectId,
                        principalTable: "Projects",
                        principalColumn: "projectId",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_TaskUser_Task_TaskLinkId",
                        column: x => x.TaskLinkId,
                        principalTable: "Task",
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
                name: "IX_ProjectsUser_Userid",
                table: "ProjectsUser",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ProjectsprojectId",
                table: "Task",
                column: "ProjectsprojectId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskUser_UserLinkid",
                table: "TaskUser",
                column: "UserLinkid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectsUser");

            migrationBuilder.DropTable(
                name: "TaskUser");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
