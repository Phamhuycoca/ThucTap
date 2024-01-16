using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Application.Dto;

namespace ThucTap.Application.IService
{
    public interface ITaiKhoanService
    {
        List<TaiKhoanDto> getAll();
        TaiKhoanDto GetById(int id);
        bool Create(TaiKhoanDto dto);
        bool Update(TaiKhoanDto dto);
        bool Delete(int id);
    }
}
