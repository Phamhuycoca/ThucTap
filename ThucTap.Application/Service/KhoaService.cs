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
    public class KhoaService:IKhoaService
    {
        private readonly IKhoaRepo _repo;
        private readonly IMapper _mapper;
        public KhoaService(IKhoaRepo repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public bool Create(KhoaDto dto)
        {
            return _repo.Create(_mapper.Map<Khoa>(dto));
        }
       
        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<KhoaDto> getAll()
        {
            return _mapper.Map<List<KhoaDto>>(_repo.getAll());
        }

        public KhoaDto GetById(int id)
        {
            return _mapper.Map<KhoaDto>(_repo.GetbyId(id));
        }

        public bool Update(KhoaDto dto)
        {
            return _repo.Update(_mapper.Map<Khoa>(dto));
        }
    }
}
