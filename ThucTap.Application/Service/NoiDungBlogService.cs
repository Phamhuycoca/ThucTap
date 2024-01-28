using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Application.Dto;
using ThucTap.Application.Helper;
using ThucTap.Application.IService;
using ThucTap.Domain.Entities;
using ThucTap.Domain.Repositories;
using ThucTap.Domain.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace ThucTap.Application.Service
{
    public class NoiDungBlogService : INoiDungBlogService
    {
        private readonly INoiDungBlogRepo _repo;
        private readonly IMapper _mapper;
        private readonly IBlogService _blogService;
        private readonly IHinhAnhBlogService _hinhAnhBlogService;
        public NoiDungBlogService(INoiDungBlogRepo repo, IMapper mapper,IBlogService blogService,IHinhAnhBlogService hinhAnhBlogService)
        {
            _mapper = mapper;
            _repo = repo;
            _blogService = blogService;
            _hinhAnhBlogService = hinhAnhBlogService;
        }
        public bool Create(NoiDungBlogDto dto)
        {
            return _repo.Create(_mapper.Map<NoiDungBlog>(dto));
        }

        public void CreateBlogContent(BlogContentCreate model, IList<IFormFile> listFile)
        {
            try
            {
                //thêm nôi dung contentBLog
                NoiDungBlogDto blog = new NoiDungBlogDto()
                {
                    BlogId = model.BlogId,
                    NoiDung=model.NoiDung,
                };
                _repo.Create(_mapper.Map<NoiDungBlog>(blog));
                var NoiDungBlogId = _repo.getAll().LastOrDefault().NoiDungBlogId;
                foreach (var item in listFile)
                {
                    string path = ServiceImage.createImage(item);
                    if (!string.IsNullOrEmpty(path))
                    {
                        HinhAnhBlogDto hinh = new HinhAnhBlogDto()
                        {
                            HinhAnhBlogUrl = path,
                            NoiDungBlogId = NoiDungBlogId,
                            UrlApi=model.UrlApi
                        };
                        _hinhAnhBlogService.Create(hinh);
                        
                    }
                }
               
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }

        public void UpdateBlogContent(NoiDungBlogDto model, IList<IFormFile> listFile, List<HinhAnhBlog> listFileDelete,string url)
        {
            //UPdate nội dung blog
            try
            {
                NoiDungBlogDto blog = new NoiDungBlogDto()
                {
                    BlogId = model.BlogId,
                    NoiDung = model.NoiDung,
                    NoiDungBlogId = model.NoiDungBlogId
                };
                _repo.Update(_mapper.Map<NoiDungBlog>(model));
                foreach (var item in listFileDelete)
                {
                    //DeleteHinhAnhBlogById(item.HinhAnhBlogId);
                    //var imageDeletes = _hinhAnhBlogService.getAllById(item.NoiDungBlogId).ToList();
                    //foreach (var image in imageDeletes)
                    //{
                        ServiceImage.deleteImage(item.HinhAnhBlogUrl);
                        _hinhAnhBlogService.Delete(item.HinhAnhBlogId);

                    //}
                    //_hinhAnhBlogService.Delete(item.HinhAnhBlogId);
                }
                foreach (var item in listFile)
                {
                    string path = ServiceImage.createImage(item);
                    if (!string.IsNullOrEmpty(path))
                    {
                        HinhAnhBlogDto hinh = new HinhAnhBlogDto()
                        {
                            HinhAnhBlogUrl = path,
                            NoiDungBlogId = model.NoiDungBlogId,
                            UrlApi=url
                    };
                        _hinhAnhBlogService.Create(hinh);
                    }
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public bool Delete(int id)
        {
            var hinhanh=_hinhAnhBlogService.getAll().Where(x=>x.NoiDungBlogId == id);
            foreach(var item in hinhanh)
            {
                ServiceImage.deleteImage(item.HinhAnhBlogUrl);
                _hinhAnhBlogService.Delete(item.HinhAnhBlogId);
            }
            return _repo.Delete(id);
        }

        public void DeleteHinhAnhBlogById(int id)
        {
            try
            {
                var imageDelete = _hinhAnhBlogService.GetById(id);
                    ServiceImage.deleteImage(imageDelete.HinhAnhBlogUrl);
                    _hinhAnhBlogService.Delete(imageDelete.HinhAnhBlogId);
            }
            catch (Exception ex)
            {

            }
        }

        public List<NoiDungBlogDto> getAll()
        {
            return _mapper.Map<List<NoiDungBlogDto>>(_repo.getAll());
        }

        public NoiDungBlogDto GetById(int id)
        {
            return _mapper.Map<NoiDungBlogDto>(_repo.GetbyId(id));
        }

        public bool Update(NoiDungBlogDto dto)
        {
            return _repo.Update(_mapper.Map<NoiDungBlog>(dto));
        }

        public List<NoiDungBlogDto> getByIdBlog(int id)
        {
            var query= _mapper.Map<List<NoiDungBlogDto>>(_repo.getAll().Where(x=>x.BlogId==id));
            return query.ToList();
        }
    }
}
