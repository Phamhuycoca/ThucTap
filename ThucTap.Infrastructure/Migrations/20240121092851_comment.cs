using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThucTap.Infrastructure.Migrations
{
    public partial class comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentBaiViet",
                columns: table => new
                {
                    CommentBaiVietId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiKhoanId = table.Column<int>(type: "int", nullable: false),
                    BaiVietId = table.Column<int>(type: "int", nullable: false),
                    NoiDungComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayComment = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentBaiViet", x => x.CommentBaiVietId);
                    table.ForeignKey(
                        name: "FK_CommentBaiViet_BaiViet_BaiVietId",
                        column: x => x.BaiVietId,
                        principalTable: "BaiViet",
                        principalColumn: "BaiVietId");
                    table.ForeignKey(
                        name: "FK_CommentBaiViet_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "TaiKhoanId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentBaiViet_BaiVietId",
                table: "CommentBaiViet",
                column: "BaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentBaiViet_TaiKhoanId",
                table: "CommentBaiViet",
                column: "TaiKhoanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentBaiViet");
        }
    }
}
