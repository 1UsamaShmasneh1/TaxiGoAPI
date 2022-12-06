using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiGoAPI.Migrations
{
    public partial class jj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b57afdf2-5c0e-4621-b61b-c025bc9ee435", 0, "15b03041-4f5f-4a8d-9c79-7babc30d67a3", "admin@admin.com", false, "Admin", "Admin", false, null, null, null, "AQAAAAEAACcQAAAAEJnBTuDUEUN9d/wou7DO753pkuvJ2Gncv5FSavet32eSGTf+8tV5+RIwvrpMnbI7sg==", "0524585648", false, "Admin", "4786a377-099e-44da-aad5-eeb7a4b99d77", false, "admin@admin.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b57afdf2-5c0e-4621-b61b-c025bc9ee435");
        }
    }
}
