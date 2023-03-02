using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskKevin.Migrations
{
    public partial class ChangesToTestUsers1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "userTable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "userTable",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
