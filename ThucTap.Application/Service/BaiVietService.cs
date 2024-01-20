﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Application.Dto;
using ThucTap.Application.Helper;
using ThucTap.Application.IService;
using ThucTap.Domain.Entities;
using ThucTap.Domain.Repositories;
using ThucTap.Domain.ViewModels;

namespace ThucTap.Application.Service
{
    public class BaiVietService : IBaiVietService
    {
        private readonly IBaiVietRepo _repo;
        private readonly IMapper _mapper;
        private readonly IHinhAnhBaiVietService _hinhAnhBlogRepo;
        public BaiVietService(IBaiVietRepo repo, IMapper mapper, IHinhAnhBaiVietService hinhAnhBlogRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _hinhAnhBlogRepo = hinhAnhBlogRepo;
        }

        public bool Create(BaiVietDto dto)
        {
            return _repo.Create(_mapper.Map<BaiViet>(dto));
        }

        public void CreateBaiViet(BaiVietCreate model, IList<IFormFile> listFile)
        {
            BaiVietDto baiviet = new BaiVietDto()
            {
                NgayDang = model.NgayDang,
                NoiDung = model.NoiDung,
                TaiKhoanId = model.TaiKhoanId,
                TieuDe = model.TieuDe,
                TrangThaiBaiViet = 1
            };
            _repo.Create(_mapper.Map<BaiViet>(baiviet));
            var BaiVietId = _repo.getAll().LastOrDefault().BaiVietId;
            foreach (var item in listFile)
            {
                string path = ServiceImage.createImage(item);
                if (!string.IsNullOrEmpty(path))
                {
                    HinhAnhBaiVietDto hinh = new HinhAnhBaiVietDto()
                    {
                        HinhAnhUrl = path,
                        BaiVietId = BaiVietId,
                        UrlApi = model.UrlApi
                    };
                    _hinhAnhBlogRepo.Create(hinh);
                }
            }
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<BaiVietDto> getAll()
        {
            return _mapper.Map<List<BaiVietDto>>(_repo.getAll());
        }

        public BaiVietDto GetById(int id)
        {
            return _mapper.Map<BaiVietDto>(_repo.GetbyId(id));
        }

        public bool Update(BaiVietDto dto)
        {
            return _repo.Update(_mapper.Map<BaiViet>(dto));
        }

        public void UpdateBaiViet(BaiVietDto model, IList<IFormFile> listFile, List<HinhAnhBaiViet> listFileDelete, string url)
        {
            try
            {
                BaiVietDto dto = new BaiVietDto()
                {
                    BaiVietId = model.BaiVietId,
                    NgayDang = model.NgayDang,
                    NoiDung = model.NoiDung,
                    TaiKhoanId = model.TaiKhoanId,
                    TieuDe = model.TieuDe,
                    TrangThaiBaiViet = model.TrangThaiBaiViet
                };
                _repo.Update(_mapper.Map<BaiViet>(dto));
                foreach (var item in listFileDelete)
                {
                    ServiceImage.deleteImage(item.HinhAnhUrl);
                    _hinhAnhBlogRepo.Delete(item.HinhAnhId);
                }
                foreach (var item in listFile)
                {
                    string path = ServiceImage.createImage(item);
                    if (!string.IsNullOrEmpty(path))
                    {
                        HinhAnhBaiVietDto hinh = new HinhAnhBaiVietDto()
                        {
                            HinhAnhUrl = path,
                            BaiVietId = model.BaiVietId,
                            UrlApi = UrlApi
                        };
                        _hinhAnhBlogRepo.Create(hinh);
                    }
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }
    }
}
