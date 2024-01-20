using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Application.Dto;
using ThucTap.Domain.ViewModels;

namespace ThucTap.Application.IService
{
    public interface ICommentBlogService
    {
        List<CommentBlogDto> getAll();
        CommentBlogDto GetById(int id);
        bool Create(CommentBlogDto dto);
        bool Update(CommentBlogDto dto);
        List<CommentBlogTaiKhoan> getAllByBlogId();
        bool Delete(int id);
    }
}
