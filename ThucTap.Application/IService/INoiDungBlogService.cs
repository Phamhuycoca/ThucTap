using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Application.Dto;
using ThucTap.Domain.Entities;
using ThucTap.Domain.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace ThucTap.Application.IService
{
    public interface INoiDungBlogService
    {
        List<NoiDungBlogDto> getAll();
        NoiDungBlogDto GetById(int id);
        bool Create(NoiDungBlogDto dto);
        bool Update(NoiDungBlogDto dto);
        bool Delete(int id);
        void CreateBlogContent(BlogContentCreate model, IList<IFormFile> listFile);
        void UpdateBlogContent(NoiDungBlogDto model, IList<IFormFile> listFile, List<HinhAnhBlog> listFileDelete, string url);
        void DeleteHinhAnhBlogById(int id);

    }
}
