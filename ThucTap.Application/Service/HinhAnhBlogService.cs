using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Application.Dto;
using ThucTap.Application.IService;
using ThucTap.Domain.Entities;
using ThucTap.Domain.Repositories;

namespace ThucTap.Application.Service
{
    public class HinhAnhBlogService : IHinhAnhBlogService
    {
        private readonly IHinhAnhBlogRepo _repo;
        private readonly IMapper _mapper;
        public HinhAnhBlogService(IHinhAnhBlogRepo repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public bool Create(HinhAnhBlogDto dto)
        {
            return _repo.Create(_mapper.Map<HinhAnhBlog>(dto));
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<HinhAnhBlogDto> getAll()
        {
            return _mapper.Map<List<HinhAnhBlogDto>>(_repo.getAll());
        }

        public List<HinhAnhBlogDto> getAllById(int id)
        {
            return _mapper.Map<List<HinhAnhBlogDto>>(_repo.getAll().Where(x=>x.NoiDungBlogId==id).ToList());
        }

        public HinhAnhBlogDto GetById(int id)
        {
            return _mapper.Map<HinhAnhBlogDto>(_repo.GetbyId(id));
        }

        public bool Update(HinhAnhBlogDto dto)
        {
            return _repo.Update(_mapper.Map<HinhAnhBlog>(dto));
        }
    }
}
