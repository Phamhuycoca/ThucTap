using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Application.Dto;
using ThucTap.Domain.Entities;

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
        }
    }
}
