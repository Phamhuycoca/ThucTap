using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Domain.Entities;
using ThucTap.Domain.Repositories;
using ThucTap.Infrastructure.Context;

namespace ThucTap.Infrastructure.Repositories
{
    public class KhoaRepo : Repo<Khoa>, IKhoaRepo
    {
        public KhoaRepo(ThucTapContext context) : base(context)
        {
        }
    }
}
