using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Domain.Entities;

namespace ThucTap.Infrastructure.Context
{
    public class ThucTapContext: DbContext
    {
        public ThucTapContext(DbContextOptions<ThucTapContext> options) : base(options) 
        {

        }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<Mon> Mons { get; set; }
        public virtual DbSet<HinhAnhBaiViet> HinhAnhBaiViets { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<BaiViet> BaiViets { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<NoiDungBlog> NoiDungBlogs { get; set; }
        public virtual DbSet<HinhAnhBlog> HinhAnhBlogs { get; set; }
        public virtual DbSet<CommentBlog> CommentBlogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Khoa>(e =>
            {
                e.ToTable("Khoa");
                e.HasKey(e => e.KhoaId);
            });
            modelBuilder.Entity<Mon>(e =>
            {
                e.ToTable("Mon");
                e.HasKey(e => e.MonId);
                e.HasOne(e => e.khoa).WithMany(e => e.mons).HasForeignKey(e => e.KhoaId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<HinhAnhBaiViet>(e =>
            {
                e.ToTable("HinhAnhBaiViet");
                e.HasKey(e => e.HinhAnhId);
                e.HasOne(e => e.baiViet).WithMany(e => e.hinhAnh).HasForeignKey(e => e.BaiVietId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<TaiKhoan>(e =>
            {
                e.ToTable("TaiKhoan");
                e.HasKey(e => e.TaiKhoanId);
                e.HasOne(e => e.khoa).WithMany(e => e.taiKhoans).HasForeignKey(e => e.KhoaId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<BaiViet>(e =>
            {
                e.ToTable("BaiViet");
                e.HasKey(e => e.BaiVietId);
            });
            modelBuilder.Entity<Blog>(e =>
            {
                e.ToTable("Blog");
                e.HasKey(e => e.BlogId);
                e.HasOne(e => e.taiKhoan).WithMany(e => e.blogs).HasForeignKey(e => e.TaiKhoanId).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasOne(e => e.khoa).WithMany(e => e.blogs).HasForeignKey(e => e.KhoaId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<NoiDungBlog>(e =>
            {
                e.ToTable("NoiDungBlog");
                e.HasKey(e => e.NoiDungBlogId);
                e.HasOne(e => e.blog).WithMany(e => e.noiDungBlogs).HasForeignKey(e => e.BlogId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<HinhAnhBlog>(e =>
            {
                e.ToTable("HinhAnhBlog");
                e.HasKey(e => e.HinhAnhBlogId);
                e.HasOne(e => e.noiDungBlog).WithMany(e => e.hinhAnhBlogs).HasForeignKey(e => e.NoiDungBlogId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<CommentBlog>(e =>
            {
                e.ToTable("CommentBlog");
                e.HasKey(e => e.CommentBlogId);
                e.HasOne(e => e.blog).WithMany(e => e.commentBlogs).HasForeignKey(e => e.BlogId).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasOne(e => e.taiKhoan).WithMany(e => e.commentBlogs).HasForeignKey(e => e.TaiKhoanId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
