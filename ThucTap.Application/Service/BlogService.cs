using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Application.Dto;
using ThucTap.Application.IService;
using ThucTap.Domain.Entities;
using ThucTap.Domain.Repositories;
using ThucTap.Domain.ViewModels;

namespace ThucTap.Application.Service
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepo _repo;
        private readonly IMapper _mapper;
        private readonly ITaiKhoanService _taikhoanService;
        private readonly IKhoaService _khoaService;
        private readonly INotiRepo _otiRepo;
        private readonly INoiDungBlogRepo _nutiDungBlogService;
        private readonly IHinhAnhBlogRepo _hinhAnhBlogRepo;
        private readonly ICommentBlogRepo _commentBlogRepo;
           
        public BlogService(IBlogRepo repo, IMapper mapper, ITaiKhoanService taikhoanService, IKhoaService khoaService, INotiRepo otiRepo, INoiDungBlogRepo noiDungBlogService,IHinhAnhBlogRepo hinhAnhBlogRepo,ICommentBlogRepo commentBlogRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _taikhoanService = taikhoanService;
            _khoaService = khoaService;
            _otiRepo = otiRepo;
            _nutiDungBlogService = noiDungBlogService;
            _hinhAnhBlogRepo = hinhAnhBlogRepo;
            _commentBlogRepo = commentBlogRepo;
        }

        public bool Create(BlogDto dto)
        {
            return _repo.Create(_mapper.Map<Blog>(dto));
        }

        public bool Delete(int id)
        {
            var noti=_otiRepo.getAll().Where(x=>x.BlogId==id);
            foreach(var item in noti)
            {
                _otiRepo.Delete(item.NotiId);
            }
            var noidung = _nutiDungBlogService.getAll().Where(x => x.BlogId == id);
            foreach(var item in noidung)
            {
                var hinhanh = _hinhAnhBlogRepo.getAll().Where(x => x.NoiDungBlogId == item.NoiDungBlogId);
                foreach(var hin in hinhanh)
                {
                    _hinhAnhBlogRepo.Delete(hin.HinhAnhBlogId);
                }
                _nutiDungBlogService.Delete(item.NoiDungBlogId);
            }
            var comments = _commentBlogRepo.getAll().Where(x => x.BlogId == id);
            foreach(var comment in comments)
            {
                _commentBlogRepo.Delete(comment.CommentBlogId);
            }
            return _repo.Delete(id);
        }

        public List<BlogDto> getAll()
        {
            return _mapper.Map<List<BlogDto>>(_repo.getAll().OrderByDescending(x => x.BlogId).ToList());

            // Sử dụng LINQ để lọc và sắp xếp các bài đăng theo thứ tự mới nhất.

        }

        public List<BlogListDto> getAllByIdKhoa(int id)
        {
            var blogs = from blog in _repo.getAll()
                        join taikhoan in _taikhoanService.getAll() on blog.TaiKhoanId equals taikhoan.TaiKhoanId
                        join khoa in _khoaService.getAll() on blog.KhoaId equals khoa.KhoaId
                        where blog.KhoaId == id
                        select new BlogList
                        {
                            BlogId = blog.BlogId,
                            HoVaTen = taikhoan.HoVaTen,
                            KhoaId = khoa.KhoaId,
                            NgayDang = blog.NgayDang,
                            TaiKhoanId = blog.TaiKhoanId,
                            TenKhoa = khoa.TenKhoa,
                            TieuDe = blog.TieuDe
                        };

            var orderedBlogs = blogs.OrderByDescending(blog => blog.BlogId).ToList();

            return _mapper.Map<List<BlogListDto>>(orderedBlogs);
        }



        public BlogDto GetById(int id)
        {
            return _mapper.Map<BlogDto>(_repo.GetbyId(id));
        }

        public bool Update(BlogDto dto)
        {
            return _repo.Update(_mapper.Map<Blog>(dto));
        }
        public BlogDto GetNew()
        {
            var firstBlog = _repo.getAll().OrderBy(x => x.NgayDang).LastOrDefault();

            return _mapper.Map<BlogDto>(firstBlog);
        }

        public List<BlogListDto> getBlogGanDay()
        {
            DateTime daysAgo = DateTime.Now.AddDays(-7);

            /* var recentBlogs = _repo.getAll()
                                    .Where(blog => blog.NgayDang >= daysAgo)
                                    .OrderByDescending(blog => blog.NgayDang)
                                    .ToList();*/
            var blogs = from blog in _repo.getAll()
                        join
                       taikhoan in _taikhoanService.getAll() on blog.TaiKhoanId equals taikhoan.TaiKhoanId
                        join
                       khoa in _khoaService.getAll() on blog.KhoaId equals khoa.KhoaId
                        select new BlogList
                        {
                            BlogId = blog.BlogId,
                            HoVaTen = taikhoan.HoVaTen,
                            KhoaId = khoa.KhoaId,
                            NgayDang = blog.NgayDang,
                            TaiKhoanId = blog.TaiKhoanId,
                            TenKhoa = khoa.TenKhoa,
                            TieuDe = blog.TieuDe
                        };
            var recentBlogs = blogs.Where(blog => blog.NgayDang >= daysAgo)
                                   .OrderByDescending(blog => blog.BlogId)
                                   .ToList();
            if (recentBlogs.Count > 1)
            {
                var maxBlogId = recentBlogs.Max(blog => blog.BlogId);
                var recentBlogsExcludingMax = recentBlogs
                    .Where(blog => blog.BlogId != maxBlogId)
                    .ToList();

                return _mapper.Map<List<BlogListDto>>(recentBlogsExcludingMax);
            }
            else
            {
                return new List<BlogListDto>();
            }
        }

        public BlogListDto getByIdBlog(int id)
        {
            var blogDto = (from blog in _repo.getAll()
                           join taikhoan in _taikhoanService.getAll() on blog.TaiKhoanId equals taikhoan.TaiKhoanId
                           join khoa in _khoaService.getAll() on blog.KhoaId equals khoa.KhoaId
                           where blog.BlogId == id
                           select new BlogListDto
                           {
                               BlogId = blog.BlogId,
                               HoVaTen = taikhoan.HoVaTen,
                               KhoaId = khoa.KhoaId,
                               NgayDang = blog.NgayDang,
                               TaiKhoanId = blog.TaiKhoanId,
                               TenKhoa = khoa.TenKhoa,
                               TieuDe = blog.TieuDe
                           }).SingleOrDefault();

            return blogDto;
        }

        public List<BlogListDto> GetAll()
        {
            var blogs = from blog in _repo.getAll()
                        join
                       taikhoan in _taikhoanService.getAll() on blog.TaiKhoanId equals taikhoan.TaiKhoanId
                        join
                       khoa in _khoaService.getAll() on blog.KhoaId equals khoa.KhoaId
                        orderby blog.BlogId
                        select new BlogList
                        {
                            BlogId = blog.BlogId,
                            HoVaTen = taikhoan.HoVaTen,
                            KhoaId = khoa.KhoaId,
                            NgayDang = blog.NgayDang,
                            TaiKhoanId = blog.TaiKhoanId,
                            TenKhoa = khoa.TenKhoa,
                            TieuDe = blog.TieuDe
                        };
            var recentBlogs = blogs
                                  .OrderByDescending(blog => blog.BlogId)
                                  .ToList();
            return _mapper.Map<List<BlogListDto>>(recentBlogs);
        }
    }
}
