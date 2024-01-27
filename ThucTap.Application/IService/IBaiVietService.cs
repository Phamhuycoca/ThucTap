using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Application.Dto;
using ThucTap.Domain.Entities;
using ThucTap.Domain.ViewModels;

namespace ThucTap.Application.IService
{
    public interface IBaiVietService
    {
        List<BaiVietDto> getAll();
        BaiVietDto GetById(int id);
        bool Create(BaiVietDto dto);
        bool Update(BaiVietDto dto);
        bool Delete(int id);
        void CreateBaiViet(BaiVietCreate model, IList<IFormFile> listFile);
        void UpdateBaiViet(BaiVietDto model, IList<IFormFile> listFile, List<HinhAnhBaiViet> listFileDelete, string url);
        List<BaiVietList> GetAll(int id);
        BaiVietList GetByIdDetail(int id);

    }
}
