using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiGoAPI.Migrations
{
    public partial class chick6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_AspNetUsers_UserId1",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_UserId1",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Drivers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Drivers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_UserId1",
                table: "Drivers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_AspNetUsers_UserId1",
                table: "Drivers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
