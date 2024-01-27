using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThucTap.Infrastructure.Migrations
{
    public partial class oai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Noti",
                columns: table => new
                {
                    NotiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaiVietId = table.Column<int>(type: "int", nullable: true),
                    BlogId = table.Column<int>(type: "int", nullable: true),
                    NotiDatetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanId = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noti", x => x.NotiId);
                    table.ForeignKey(
                        name: "FK_Noti_BaiViet_BaiVietId",
                        column: x => x.BaiVietId,
                        principalTable: "BaiViet",
                        principalColumn: "BaiVietId");
                    table.ForeignKey(
                        name: "FK_Noti_Blog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blog",
                        principalColumn: "BlogId");
                    table.ForeignKey(
                        name: "FK_Noti_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "TaiKhoanId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Noti_BaiVietId",
                table: "Noti",
                column: "BaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_Noti_BlogId",
                table: "Noti",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Noti_TaiKhoanId",
                table: "Noti",
                column: "TaiKhoanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Noti");
        }
    }
}
