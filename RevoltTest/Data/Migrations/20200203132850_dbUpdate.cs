using Microsoft.EntityFrameworkCore.Migrations;

namespace RevoltTest.Data.Migrations
{
    public partial class dbUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "UserActivities");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "UserActivities",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "UserActivities",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "UserActivities",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
