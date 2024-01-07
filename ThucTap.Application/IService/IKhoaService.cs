using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Application.Dto;

namespace ThucTap.Application.IService
{
    public interface IKhoaService
    {
        List<KhoaDto> getAll();
        KhoaDto GetById(int id);
        bool Create(KhoaDto dto);
        bool Update(KhoaDto dto);
        bool Delete(int id);
    }
}
