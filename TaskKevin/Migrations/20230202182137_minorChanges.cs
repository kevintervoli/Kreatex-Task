using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskKevin.Migrations
{
    public partial class minorChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rolesTable_userTable_userId",
                table: "rolesTable");

            migrationBuilder.DropIndex(
                name: "IX_rolesTable_userId",
                table: "rolesTable");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "rolesTable");

            migrationBuilder.AddColumn<int>(
                name: "rolesId",
                table: "userTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_userTable_rolesId",
                table: "userTable",
                column: "rolesId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_userTable_rolesTable_rolesId",
                table: "userTable",
                column: "rolesId",
                principalTable: "rolesTable",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userTable_rolesTable_rolesId",
                table: "userTable");

            migrationBuilder.DropIndex(
                name: "IX_userTable_rolesId",
                table: "userTable");

            migrationBuilder.DropColumn(
                name: "rolesId",
                table: "userTable");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "rolesTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_rolesTable_userId",
                table: "rolesTable",
                column: "userId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_rolesTable_userTable_userId",
                table: "rolesTable",
                column: "userId",
                principalTable: "userTable",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
