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
    public class CommentBaiVietService : ICommentBaiVietService
    {
        private readonly ICommentBaiVietRepo _repo;
        private readonly IMapper _mapper;
        private readonly ITaiKhoanService _taiKhoanService;
        public CommentBaiVietService(ICommentBaiVietRepo repo, IMapper mapper, ITaiKhoanService taiKhoanService)
        {
            _repo = repo;
            _mapper = mapper;
            _taiKhoanService = taiKhoanService;
        }

        public bool Create(CommentBaiVietDto dto)
        {
            return _repo.Create(_mapper.Map<CommentBaiViet>(dto));
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<CommentBaiVietDto> getAll()
        {
            return _mapper.Map<List<CommentBaiVietDto>>(_repo.getAll());
        }

        public List<CommentBaiVietTaiKhoan> getAllById()
        {
            var query = from baivietcomment in _repo.getAll()
                        join
                      taikhoan in _taiKhoanService.getAll() on baivietcomment.TaiKhoanId equals taikhoan.TaiKhoanId
                        select new CommentBaiVietTaiKhoan
                        {
                            BaiVietId= baivietcomment.BaiVietId,
                            CommentBaiVietId = baivietcomment.CommentBaiVietId,
                            HinhAnhUrl = taikhoan.HinhAnhUrl,
                            HoVaTen = taikhoan.HoVaTen,
                            NgayComment = baivietcomment.NgayComment,
                            NoiDungComment = baivietcomment.NoiDungComment,
                            TaiKhoanId = baivietcomment.TaiKhoanId
                        };
            return query.ToList();
        }

        public CommentBaiVietDto GetById(int id)
        {
            return _mapper.Map<CommentBaiVietDto>(_repo.GetbyId(id));
        }

        public bool Update(CommentBaiVietDto dto)
        {
            return _repo.Update(_mapper.Map<CommentBaiViet>(dto));
        }
    }
}
