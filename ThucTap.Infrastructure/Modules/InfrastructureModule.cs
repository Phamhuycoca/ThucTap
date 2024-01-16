using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Domain.Repositories;
using ThucTap.Infrastructure.Repositories;

namespace ThucTap.Infrastructure.Modules
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
        {
            services.AddScoped<IKhoaRepo, KhoaRepo>();
            services.AddScoped<IMonRepo, MonRepo>();
            services.AddScoped<IBlogRepo, BlogRepo>();
            services.AddScoped<INoiDungBlogRepo, NoiDungBlogRepo>();
            services.AddScoped<IHinhAnhBlogRepo, HinhAnhBlogRepo>();
            services.AddScoped<ITaiKhoanRepo, TaiKhoanRepo>();
            return services;
        }
    }
}
