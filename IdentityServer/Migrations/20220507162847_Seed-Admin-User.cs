using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServer.Migrations
{
    public partial class SeedAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02174cf0–9412–4cfe-afbf-59f706d72cf6", 0, "3abccc45-921a-42b7-a838-4ba889998ee8", "Admin@byMe.com", true, false, null, "ADMIN@byMe.COM", "ADMIN@byMe.COM", "AQAAAAEAACcQAAAAEKGiaSdMWKAm9WlnD3TPtwOJcPbJmCl+in71Bz7MUFpIBQ7Z8xjYWuIsJT+f6h9z5A==", null, false, "a7656c8b-68a1-43b6-a108-eadb7caa82a7", false, "Admin@byMe.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6");
        }
    }
}
