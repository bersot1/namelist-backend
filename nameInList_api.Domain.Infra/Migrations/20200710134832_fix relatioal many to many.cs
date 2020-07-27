using Microsoft.EntityFrameworkCore.Migrations;

namespace nameInList_api.Domain.Infra.Migrations
{
    public partial class fixrelatioalmanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserListas_Listas_Id",
                table: "UserListas");

            migrationBuilder.DropForeignKey(
                name: "FK_UserListas_Users_Id",
                table: "UserListas");

            migrationBuilder.DropIndex(
                name: "IX_UserListas_Id",
                table: "UserListas");

            migrationBuilder.CreateIndex(
                name: "IX_UserListas_ListaId",
                table: "UserListas",
                column: "ListaId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserListas_Listas_ListaId",
                table: "UserListas",
                column: "ListaId",
                principalTable: "Listas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserListas_Users_UserId",
                table: "UserListas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserListas_Listas_ListaId",
                table: "UserListas");

            migrationBuilder.DropForeignKey(
                name: "FK_UserListas_Users_UserId",
                table: "UserListas");

            migrationBuilder.DropIndex(
                name: "IX_UserListas_ListaId",
                table: "UserListas");

            migrationBuilder.CreateIndex(
                name: "IX_UserListas_Id",
                table: "UserListas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserListas_Listas_Id",
                table: "UserListas",
                column: "Id",
                principalTable: "Listas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserListas_Users_Id",
                table: "UserListas",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
