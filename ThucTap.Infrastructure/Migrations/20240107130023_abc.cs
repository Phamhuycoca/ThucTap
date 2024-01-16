using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThucTap.Infrastructure.Migrations
{
    public partial class abc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDang = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanId = table.Column<int>(type: "int", nullable: false),
                    KhoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.BlogId);
                    table.ForeignKey(
                        name: "FK_Blog_Khoa_KhoaId",
                        column: x => x.KhoaId,
                        principalTable: "Khoa",
                        principalColumn: "KhoaId");
                    table.ForeignKey(
                        name: "FK_Blog_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "TaiKhoanId");
                });

            migrationBuilder.CreateTable(
                name: "NoiDungBlog",
                columns: table => new
                {
                    NoiDungBlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoiDungBlog", x => x.NoiDungBlogId);
                    table.ForeignKey(
                        name: "FK_NoiDungBlog_Blog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blog",
                        principalColumn: "BlogId");
                });

            migrationBuilder.CreateTable(
                name: "HinhAnhBlog",
                columns: table => new
                {
                    HinhAnhBlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HinhAnhBlogUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDungBlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhAnhBlog", x => x.HinhAnhBlogId);
                    table.ForeignKey(
                        name: "FK_HinhAnhBlog_NoiDungBlog_NoiDungBlogId",
                        column: x => x.NoiDungBlogId,
                        principalTable: "NoiDungBlog",
                        principalColumn: "NoiDungBlogId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_KhoaId",
                table: "Blog",
                column: "KhoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_TaiKhoanId",
                table: "Blog",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnhBlog_NoiDungBlogId",
                table: "HinhAnhBlog",
                column: "NoiDungBlogId");

            migrationBuilder.CreateIndex(
                name: "IX_NoiDungBlog_BlogId",
                table: "NoiDungBlog",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HinhAnhBlog");

            migrationBuilder.DropTable(
                name: "NoiDungBlog");

            migrationBuilder.DropTable(
                name: "Blog");
        }
    }
}
