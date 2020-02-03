using Microsoft.EntityFrameworkCore.Migrations;

namespace RevoltTest.Data.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ID1",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ID2",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ID2",
                table: "AspNetUsers");
        }
    }
}
