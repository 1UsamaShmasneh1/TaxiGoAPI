using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiGoAPI.Migrations
{
    public partial class chick : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerPhone",
                table: "Customers",
                newName: "CostomerPhone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CostomerPhone",
                table: "Customers",
                newName: "CustomerPhone");
        }
    }
}
