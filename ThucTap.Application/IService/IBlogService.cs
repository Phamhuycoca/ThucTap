using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Application.Dto;

namespace ThucTap.Application.IService
{
    public interface IBlogService
    {
        List<BlogDto> getAll();
        BlogDto GetById(int id);
        bool Create(BlogDto dto);
        bool Update(BlogDto dto);
        bool Delete(int id);
        List<BlogListDto> getAllByIdKhoa(int id);
        List<BlogListDto> getBlogGanDay();
        BlogDto GetNew();
    }
}
