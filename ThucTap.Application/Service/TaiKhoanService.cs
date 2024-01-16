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
    public class TaiKhoanService : ITaiKhoanService
    {
        private readonly ITaiKhoanRepo _repo;
        private readonly IMapper _mapper;
        public TaiKhoanService(ITaiKhoanRepo repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public bool Create(TaiKhoanDto dto)
        {
            return _repo.Create(_mapper.Map<TaiKhoan>(dto));
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<TaiKhoanDto> getAll()
        {
            return _mapper.Map<List<TaiKhoanDto>>(_repo.getAll());
        }

        public TaiKhoanDto GetById(int id)
        {
            return _mapper.Map<TaiKhoanDto>(_repo.GetbyId(id));
        }

        public bool Update(TaiKhoanDto dto)
        {
            return _repo.Update(_mapper.Map<TaiKhoan>(dto));
        }
    }
}
