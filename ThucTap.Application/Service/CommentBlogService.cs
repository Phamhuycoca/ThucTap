using AutoMapper;
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
    public class CommentBlogService : ICommentBlogService
    {
        private readonly ICommentBlogRepo _repo;
        private readonly IMapper _mapper;
        private readonly ITaiKhoanRepo _takhoanService;
        public CommentBlogService(ICommentBlogRepo repo, IMapper mapper, ITaiKhoanRepo taiKhoanService)
        {
            _repo = repo;
            _mapper = mapper;
            _takhoanService = taiKhoanService;
        }
        public bool Create(CommentBlogDto dto)
        {
            return _repo.Create(_mapper.Map<CommentBlog>(dto));
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<CommentBlogDto> getAll()
        {
            return _mapper.Map<List<CommentBlogDto>>(_repo.getAll());
        }

        public List<CommentBlogTaiKhoan> getAllByBlogId()
        {
            var query = from blogcoment in _repo.getAll()
                        join
                      taikhoan in _takhoanService.getAll() on blogcoment.TaiKhoanId equals taikhoan.TaiKhoanId
                        select new CommentBlogTaiKhoan
                        {
                            BlogId = blogcoment.BlogId,
                            CommentBlogId = blogcoment.CommentBlogId,
                            HinhAnhUrl = taikhoan.HinhAnhUrl,
                            HoVaTen = taikhoan.HoVaTen,
                            NgayComment = blogcoment.NgayComment,
                            NoiDungComment = blogcoment.NoiDungComment,
                            TaiKhoanId = blogcoment.TaiKhoanId
                        };
            return query.ToList();

        }

        public CommentBlogDto GetById(int id)
        {
            return _mapper.Map<CommentBlogDto>(_repo.GetbyId(id));
        }

        public bool Update(CommentBlogDto dto)
        {
            return _repo.Update(_mapper.Map<CommentBlog>(dto));

        }
    }
}
