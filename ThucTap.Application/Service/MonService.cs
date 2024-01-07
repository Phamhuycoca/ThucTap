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
    public class MonService : IMonService
    {
        private readonly IMonRepo _repo;
        private readonly IMapper _mapper;
        public MonService(IMonRepo repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public bool Create(MonDto dto)
        {
            return _repo.Create(_mapper.Map<Mon>(dto));
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<MonDto> getAll()
        {
            return _mapper.Map<List<MonDto>>(_repo.getAll());
        }

        public MonDto GetById(int id)
        {
            return _mapper.Map<MonDto>(_repo.GetbyId(id));
        }

        public bool Update(MonDto dto)
        {
            return _repo.Update(_mapper.Map<Mon>(dto));
        }
    }
}
