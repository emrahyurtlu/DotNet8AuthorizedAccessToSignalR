using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net8Identity.Migrations
{
    /// <inheritdoc />
    public partial class SeedTestUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CustomProperty", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "86bd891e-3a35-4b35-8749-b60eac04d462", 0, "9bc132c2-809c-4865-b213-2fa7b862f1ee", null, "test@test.com", false, false, null, null, null, "AQAAAAIAAYagAAAAECdBxDUaMDZT5sb1X48P3VL8/devtcU74K2Eg4X153cI6TcQ9wm5niAyYqqDbqad+w==", null, false, "8436ce2e-31ac-4b20-9ec4-161b69dea801", false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86bd891e-3a35-4b35-8749-b60eac04d462");
        }
    }
}
