using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Application.Dto;
using ThucTap.Domain.ViewModels;

namespace ThucTap.Application.IService
{
    public interface ICommentBaiVietService
    {
        List<CommentBaiVietDto> getAll();
        CommentBaiVietDto GetById(int id);
        bool Create(CommentBaiVietDto dto);
        bool Update(CommentBaiVietDto dto);
        bool Delete(int id);
        List<CommentBaiVietTaiKhoan> getAllById();
    }
}
