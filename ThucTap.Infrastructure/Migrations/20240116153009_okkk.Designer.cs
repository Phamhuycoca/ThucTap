﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThucTap.Infrastructure.Context;

#nullable disable

namespace ThucTap.Infrastructure.Migrations
{
    [DbContext(typeof(ThucTapContext))]
    [Migration("20240116153009_okkk")]
    partial class okkk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ThucTap.Domain.Entities.BaiViet", b =>
                {
                    b.Property<int>("BaiVietId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BaiVietId"), 1L, 1);

                    b.Property<DateTime?>("NgayDang")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TaiKhoanId")
                        .HasColumnType("int");

                    b.Property<string>("TieuDe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrangThaiBaiViet")
                        .HasColumnType("int");

                    b.HasKey("BaiVietId");

                    b.HasIndex("TaiKhoanId");

                    b.ToTable("BaiViet", (string)null);
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlogId"), 1L, 1);

                    b.Property<int>("KhoaId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayDang")
                        .HasColumnType("datetime2");

                    b.Property<int>("TaiKhoanId")
                        .HasColumnType("int");

                    b.Property<string>("TieuDe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BlogId");

                    b.HasIndex("KhoaId");

                    b.HasIndex("TaiKhoanId");

                    b.ToTable("Blog", (string)null);
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.CommentBlog", b =>
                {
                    b.Property<int>("CommentBlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentBlogId"), 1L, 1);

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayComment")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDungComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaiKhoanId")
                        .HasColumnType("int");

                    b.HasKey("CommentBlogId");

                    b.HasIndex("BlogId");

                    b.HasIndex("TaiKhoanId");

                    b.ToTable("CommentBlog", (string)null);
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.HinhAnhBaiViet", b =>
                {
                    b.Property<int>("HinhAnhId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HinhAnhId"), 1L, 1);

                    b.Property<int>("BaiVietId")
                        .HasColumnType("int");

                    b.Property<string>("HinhAnhUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HinhAnhId");

                    b.HasIndex("BaiVietId");

                    b.ToTable("HinhAnhBaiViet", (string)null);
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.HinhAnhBlog", b =>
                {
                    b.Property<int>("HinhAnhBlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HinhAnhBlogId"), 1L, 1);

                    b.Property<string>("HinhAnhBlogUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoiDungBlogId")
                        .HasColumnType("int");

                    b.Property<string>("UrlApi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HinhAnhBlogId");

                    b.HasIndex("NoiDungBlogId");

                    b.ToTable("HinhAnhBlog", (string)null);
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.Khoa", b =>
                {
                    b.Property<int>("KhoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KhoaId"), 1L, 1);

                    b.Property<string>("TenKhoa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KhoaId");

                    b.ToTable("Khoa", (string)null);
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.Mon", b =>
                {
                    b.Property<int>("MonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MonId"), 1L, 1);

                    b.Property<int>("KhoaId")
                        .HasColumnType("int");

                    b.Property<string>("TenMon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MonId");

                    b.HasIndex("KhoaId");

                    b.ToTable("Mon", (string)null);
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.NoiDungBlog", b =>
                {
                    b.Property<int>("NoiDungBlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NoiDungBlogId"), 1L, 1);

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NoiDungBlogId");

                    b.HasIndex("BlogId");

                    b.ToTable("NoiDungBlog", (string)null);
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.TaiKhoan", b =>
                {
                    b.Property<int>("TaiKhoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaiKhoanId"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("GioiTinh")
                        .HasColumnType("bit");

                    b.Property<string>("HinhAnhUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoVaTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KhoaId")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaiKhoanId");

                    b.HasIndex("KhoaId");

                    b.ToTable("TaiKhoan", (string)null);
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.BaiViet", b =>
                {
                    b.HasOne("ThucTap.Domain.Entities.TaiKhoan", "taiKhoan")
                        .WithMany("baiBiets")
                        .HasForeignKey("TaiKhoanId");

                    b.Navigation("taiKhoan");
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.Blog", b =>
                {
                    b.HasOne("ThucTap.Domain.Entities.Khoa", "khoa")
                        .WithMany("blogs")
                        .HasForeignKey("KhoaId")
                        .IsRequired();

                    b.HasOne("ThucTap.Domain.Entities.TaiKhoan", "taiKhoan")
                        .WithMany("blogs")
                        .HasForeignKey("TaiKhoanId")
                        .IsRequired();

                    b.Navigation("khoa");

                    b.Navigation("taiKhoan");
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.CommentBlog", b =>
                {
                    b.HasOne("ThucTap.Domain.Entities.Blog", "blog")
                        .WithMany("commentBlogs")
                        .HasForeignKey("BlogId")
                        .IsRequired();

                    b.HasOne("ThucTap.Domain.Entities.TaiKhoan", "taiKhoan")
                        .WithMany("commentBlogs")
                        .HasForeignKey("TaiKhoanId")
                        .IsRequired();

                    b.Navigation("blog");

                    b.Navigation("taiKhoan");
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.HinhAnhBaiViet", b =>
                {
                    b.HasOne("ThucTap.Domain.Entities.BaiViet", "baiViet")
                        .WithMany("hinhAnh")
                        .HasForeignKey("BaiVietId")
                        .IsRequired();

                    b.Navigation("baiViet");
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.HinhAnhBlog", b =>
                {
                    b.HasOne("ThucTap.Domain.Entities.NoiDungBlog", "noiDungBlog")
                        .WithMany("hinhAnhBlogs")
                        .HasForeignKey("NoiDungBlogId")
                        .IsRequired();

                    b.Navigation("noiDungBlog");
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.Mon", b =>
                {
                    b.HasOne("ThucTap.Domain.Entities.Khoa", "khoa")
                        .WithMany("mons")
                        .HasForeignKey("KhoaId")
                        .IsRequired();

                    b.Navigation("khoa");
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.NoiDungBlog", b =>
                {
                    b.HasOne("ThucTap.Domain.Entities.Blog", "blog")
                        .WithMany("noiDungBlogs")
                        .HasForeignKey("BlogId")
                        .IsRequired();

                    b.Navigation("blog");
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.TaiKhoan", b =>
                {
                    b.HasOne("ThucTap.Domain.Entities.Khoa", "khoa")
                        .WithMany("taiKhoans")
                        .HasForeignKey("KhoaId");

                    b.Navigation("khoa");
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.BaiViet", b =>
                {
                    b.Navigation("hinhAnh");
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.Blog", b =>
                {
                    b.Navigation("commentBlogs");

                    b.Navigation("noiDungBlogs");
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.Khoa", b =>
                {
                    b.Navigation("blogs");

                    b.Navigation("mons");

                    b.Navigation("taiKhoans");
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.NoiDungBlog", b =>
                {
                    b.Navigation("hinhAnhBlogs");
                });

            modelBuilder.Entity("ThucTap.Domain.Entities.TaiKhoan", b =>
                {
                    b.Navigation("baiBiets");

                    b.Navigation("blogs");

                    b.Navigation("commentBlogs");
                });
#pragma warning restore 612, 618
        }
    }
}
