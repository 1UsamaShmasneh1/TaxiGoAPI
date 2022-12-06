using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiGoAPI.Migrations
{
    public partial class chick3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Taxis_TaxiId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Taxis_Drivers_DriverId",
                table: "Taxis");

            migrationBuilder.DropIndex(
                name: "IX_Requests_TaxiId",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Taxis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TaxiId",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_TaxiId",
                table: "Requests",
                column: "TaxiId",
                unique: true,
                filter: "[TaxiId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Taxis_TaxiId",
                table: "Requests",
                column: "TaxiId",
                principalTable: "Taxis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Taxis_Drivers_DriverId",
                table: "Taxis",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Taxis_TaxiId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Taxis_Drivers_DriverId",
                table: "Taxis");

            migrationBuilder.DropIndex(
                name: "IX_Requests_TaxiId",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Taxis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TaxiId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_TaxiId",
                table: "Requests",
                column: "TaxiId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Taxis_TaxiId",
                table: "Requests",
                column: "TaxiId",
                principalTable: "Taxis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Taxis_Drivers_DriverId",
                table: "Taxis",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
