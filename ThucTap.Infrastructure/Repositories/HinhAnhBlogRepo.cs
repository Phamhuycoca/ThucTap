﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Domain.Entities;
using ThucTap.Domain.Repositories;
using ThucTap.Infrastructure.Context;

namespace ThucTap.Infrastructure.Repositories
{
    public class HinhAnhBlogRepo : Repo<HinhAnhBlog>, IHinhAnhBlogRepo
    {
        public HinhAnhBlogRepo(ThucTapContext context) : base(context)
        {
        }
    }
}