using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Application.Dto;

namespace ThucTap.Application.IService
{
    public interface IMonService
    {
        List<MonDto> getAll();
        MonDto GetById(int id);
        bool Create(MonDto dto);
        bool Update(MonDto dto);
        bool Delete(int id);
    }
}
