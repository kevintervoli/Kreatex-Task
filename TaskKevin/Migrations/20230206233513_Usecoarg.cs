using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskKevin.Migrations
{
    public partial class Usecoarg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userTable_rolesTable_RoleId",
                table: "userTable");

            migrationBuilder.DropIndex(
                name: "IX_userTable_RoleId",
                table: "userTable");

            migrationBuilder.AddColumn<int>(
                name: "userLinkid",
                table: "rolesTable",
                type: "int",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rolesTable_userTable_userLinkid",
                table: "rolesTable");

            migrationBuilder.DropIndex(
                name: "IX_rolesTable_userLinkid",
                table: "rolesTable");

            migrationBuilder.DropColumn(
                name: "userLinkid",
                table: "rolesTable");

            migrationBuilder.CreateIndex(
                name: "IX_userTable_RoleId",
                table: "userTable",
                column: "RoleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_userTable_rolesTable_RoleId",
                table: "userTable",
                column: "RoleId",
                principalTable: "rolesTable",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
