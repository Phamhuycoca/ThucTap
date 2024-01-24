using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThucTap.Infrastructure.Migrations
{
    public partial class po : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "urlApi",
                table: "TaiKhoan",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "urlApi",
                table: "TaiKhoan");
        }
    }
}
