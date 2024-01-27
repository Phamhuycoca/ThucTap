using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Application.Dto;
using ThucTap.Domain.ViewModels;

namespace ThucTap.Application.IService
{
    public interface INotiService
    {
        List<NotiDto> getAll();
        NotiDto GetById(int id);
        bool Create(NotiDto dto);
        bool Update(NotiDto dto);
        bool Delete(int id);
        List<NotiTaiKhoan> getAllById(int id);
        bool SeenNoti(int id);
    }
}
