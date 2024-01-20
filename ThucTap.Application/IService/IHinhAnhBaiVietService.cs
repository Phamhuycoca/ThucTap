using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Application.Dto;

namespace ThucTap.Application.IService
{
    public interface IHinhAnhBaiVietService
    {
        List<HinhAnhBaiVietDto> getAll();
        HinhAnhBaiVietDto GetById(int id);
        bool Create(HinhAnhBaiVietDto dto);
        bool Update(HinhAnhBaiVietDto dto);
        bool Delete(int id);
        List<HinhAnhBaiVietDto> getAllById(int id);

    }
}
