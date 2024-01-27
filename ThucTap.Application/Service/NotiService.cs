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
using ThucTap.Domain.ViewModels;

namespace ThucTap.Application.Service
{
    public class NotiService : INotiService
    {
        private readonly IMapper _mapper;
        private readonly INotiRepo _repo;
        private readonly ITaiKhoanRepo _tikhoanRepo;
        public NotiService(IMapper mapper, INotiRepo repo,ITaiKhoanRepo taiKhoanRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _tikhoanRepo = taiKhoanRepo;
        }
        public bool Create(NotiDto dto)
        {
            return _repo.Create(_mapper.Map<Noti>(dto));
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<NotiDto> getAll()
        {
            return _mapper.Map<List<NotiDto>>(_repo.getAll().OrderByDescending(x=>x.NotiId));
        }

        public List<NotiTaiKhoan> getAllById(int id)
        {
            //return _mapper.Map<List<NotiDto>>(_repo.getAll().Where(x=>x.TaiKhoanId==id && x.TaiKhoanComment !=id).OrderByDescending(x => x.NotiId));
            var query = from noti in _repo.getAll().Where(x => x.TaiKhoanId == id && x.TaiKhoanComment != id && x.TrangThai ==0)
                        join taikhoan in _tikhoanRepo.getAll() on noti.TaiKhoanComment equals taikhoan.TaiKhoanId
                        orderby noti.NotiId
                        select new NotiTaiKhoan
                        {
                            BaiVietId=noti.BaiVietId,
                            BlogId=noti.BlogId,
                            NotiId=noti.NotiId,
                            NotiDatetime=noti.NotiDatetime,
                            TrangThai= noti.TrangThai,
                            TaiKhoanId= noti.TaiKhoanId,
                            TaiKhoanComment= noti.TaiKhoanComment,
                            HinhAnhUrl=taikhoan.HinhAnhUrl,
                            HoVaTen = taikhoan.HoVaTen,
                            urlApi = taikhoan.urlApi
                        };
            return query.ToList();
        }

        public NotiDto GetById(int id)
        {
            return _mapper.Map<NotiDto>(_repo.GetbyId(id));
        }

        public bool SeenNoti(int id)
        {
            var notis=_mapper.Map<List<NotiDto>>(_repo.getAll().Where(x=>x.TaiKhoanId==id));
            foreach(var item in notis)
            {
                item.TrangThai = 1;
                _repo.Update(_mapper.Map<Noti>(item));
            }
            return true;
        }

        public bool Update(NotiDto dto)
        {
         return _repo.Update(_mapper.Map<Noti>(dto));
        }
    }
}
