using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Application.Dto;
using ThucTap.Domain.Entities;

namespace ThucTap.Application.IService
{
    public interface IHinhAnhBlogService
    {
        List<HinhAnhBlogDto> getAll();
        HinhAnhBlogDto GetById(int id);
        bool Create(HinhAnhBlogDto dto);
        bool Update(HinhAnhBlogDto dto);
        bool Delete(int id);
        List<HinhAnhBlogDto> getAllById(int id);

    }
}
