using Microsoft.EntityFrameworkCore.Migrations;

namespace nameInList_api.Domain.Infra.Migrations
{
    public partial class addproplista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Listas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Listas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Listas");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Listas");
        }
    }
}
