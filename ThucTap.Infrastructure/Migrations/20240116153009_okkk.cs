using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThucTap.Infrastructure.Migrations
{
    public partial class okkk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentBlog",
                columns: table => new
                {
                    CommentBlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiKhoanId = table.Column<int>(type: "int", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    NoiDungComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayComment = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentBlog", x => x.CommentBlogId);
                    table.ForeignKey(
                        name: "FK_CommentBlog_Blog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blog",
                        principalColumn: "BlogId");
                    table.ForeignKey(
                        name: "FK_CommentBlog_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "TaiKhoanId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentBlog_BlogId",
                table: "CommentBlog",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentBlog_TaiKhoanId",
                table: "CommentBlog",
                column: "TaiKhoanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentBlog");
        }
    }
}
