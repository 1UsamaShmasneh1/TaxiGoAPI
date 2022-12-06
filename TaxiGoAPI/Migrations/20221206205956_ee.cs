using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiGoAPI.Migrations
{
    public partial class ee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b57afdf2-5c0e-4621-b61b-c025bc9ee435");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5c6f0a8e-2d03-4a26-b4b8-00b4d0aea094", 0, "88d1c17a-8ab8-4e68-8253-30a9f2bb6079", "admin@admin.com", false, "Admin", "Admin", true, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEJnBTuDUEUN9d/wou7DO753pkuvJ2Gncv5FSavet32eSGTf+8tV5+RIwvrpMnbI7sg==", "0524585648", false, "Admin", "JLS2C6J7B7CMXKZ7SL3SVLMZ7HRCGBWR", false, "admin@admin.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5c6f0a8e-2d03-4a26-b4b8-00b4d0aea094");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b57afdf2-5c0e-4621-b61b-c025bc9ee435", 0, "15b03041-4f5f-4a8d-9c79-7babc30d67a3", "admin@admin.com", false, "Admin", "Admin", false, null, null, null, "AQAAAAEAACcQAAAAEJnBTuDUEUN9d/wou7DO753pkuvJ2Gncv5FSavet32eSGTf+8tV5+RIwvrpMnbI7sg==", "0524585648", false, "Admin", "4786a377-099e-44da-aad5-eeb7a4b99d77", false, "admin@admin.com" });
        }
    }
}
