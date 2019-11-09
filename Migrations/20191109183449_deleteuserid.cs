using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskDB.MVC.Migrations
{
    public partial class deleteuserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userid",
                table: "Tasks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);
        }
    }
}
