using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskKevin.Migrations
{
    public partial class Useco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userTable_rolesTable_rolesId",
                table: "userTable");

            migrationBuilder.RenameColumn(
                name: "rolesId",
                table: "userTable",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_userTable_rolesId",
                table: "userTable",
                newName: "IX_userTable_RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_userTable_rolesTable_RoleId",
                table: "userTable",
                column: "RoleId",
                principalTable: "rolesTable",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userTable_rolesTable_RoleId",
                table: "userTable");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "userTable",
                newName: "rolesId");

            migrationBuilder.RenameIndex(
                name: "IX_userTable_RoleId",
                table: "userTable",
                newName: "IX_userTable_rolesId");

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
