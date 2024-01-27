using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThucTap.Infrastructure.Migrations
{
    public partial class wo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaiKhoanComment",
                table: "Noti",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaiKhoanComment",
                table: "Noti");
        }
    }
}
