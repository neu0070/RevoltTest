using Microsoft.EntityFrameworkCore.Migrations;

namespace RevoltTest.Data.Migrations
{
    public partial class UserInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0caa5d63-d151-4962-b825-ddac81891da2", "30a5443d-e1f4-47f6-aa50-68386ebb61ad", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0caa5d63-d151-4962-b825-ddac81891da2");
        }
    }
}
