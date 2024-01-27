using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Application.Dto;
using ThucTap.Domain.Entities;
using ThucTap.Domain.ViewModels;

namespace ThucTap.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BaiViet, BaiVietDto>().ReverseMap();
            CreateMap<Khoa, KhoaDto>().ReverseMap();
            CreateMap<Mon, MonDto>().ReverseMap();
            CreateMap<HinhAnhBaiViet, HinhAnhBaiVietDto>().ReverseMap();
            CreateMap<TaiKhoan, TaiKhoanDto>().ReverseMap();
            CreateMap<Blog, BlogDto>().ReverseMap();
            CreateMap<NoiDungBlog, NoiDungBlogDto>().ReverseMap();
            CreateMap<HinhAnhBlog, HinhAnhBlogDto>().ReverseMap();
            CreateMap<BlogList, BlogListDto>().ReverseMap();
            CreateMap<CommentBlog, CommentBlogDto>().ReverseMap();
            CreateMap<BaiVietList,BaiVietListDto>().ReverseMap();
            CreateMap<CommentBaiViet,CommentBaiVietDto>().ReverseMap();
            CreateMap<Noti, NotiDto>().ReverseMap();
        }
    }
}
