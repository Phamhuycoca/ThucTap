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
    public class HinhAnhBaiVietService : IHinhAnhBaiVietService
    {
        private readonly IHinhAnhBaiVietRepo _repo;
        private readonly IMapper _mapper;
        public HinhAnhBaiVietService(IHinhAnhBaiVietRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public bool Create(HinhAnhBaiVietDto dto)
        {
            return _repo.Create(_mapper.Map<HinhAnhBaiViet>(dto));
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<HinhAnhBaiVietDto> getAll()
        {
            return _mapper.Map<List<HinhAnhBaiVietDto>>(_repo.getAll());
        }

        public List<HinhAnhBaiVietDto> getAllById(int id)
        {
            return _mapper.Map<List<HinhAnhBaiVietDto>>(_repo.getAll().Where(x=>x.BaiVietId==id));
        }

        public HinhAnhBaiVietDto GetById(int id)
        {
            return _mapper.Map<HinhAnhBaiVietDto>(_repo.GetbyId(id));
        }

        public bool Update(HinhAnhBaiVietDto dto)
        {
            return _repo.Update(_mapper.Map<HinhAnhBaiViet>(dto));
        }
    }
}
